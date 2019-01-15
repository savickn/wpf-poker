﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    public class PokerVM : INotifyPropertyChanged {

        /* UI Properties */

        public bool ShowHideActionInterface {
            get { return this.isClientPlayerActive(); }
        }

        /* Properties */

        public string newPlayer { get; set; }
        public bool gameStatus { get; private set; }
        public bool turnInProgress { get; private set; }

        public double bigBlind { get; }
        public double smallBlind { get; }
        public double ante { get; }
        public double maxBuyIn { get; }
        public double minBuyIn { get; }
        public double timePerTurn { get; set; }


        private double turnTimer { get; set; }
        public double TurnTimer {
            get { return turnTimer; }
            set { turnTimer = value; OnPropertyChanged("TurnTimer"); }
        }

        public Seat btn { get; private set; }
        public Seat sb { get; private set; }
        public Seat bb { get; private set; }
        public Seat fp { get; private set; }

        private Deck deck;
        private Board board;
        private Pot pot;
        public Table table { get; }
        public GameStatus status { get; private set; }
        public Street street { get; private set; }
        private Player activePlayer;
        private Player clientPlayer;


        public ObservableCollection<Player> players; // represents all registered players 
        private List<Player> activePlayers; // represents players currently in hand

        public Pot Pot {
            get { return pot; }
            set { pot = value; OnPropertyChanged("Pot"); }
        }

        public Board Board {
            get { return board; }
            set { board = value; OnPropertyChanged("Board"); }
        }

        public Player ActivePlayer {
            get { return activePlayer; }
            set { this.activePlayer = value; OnPropertyChanged("ActivePlayer"); }
        }

        /* Commands */

        public ICommand StartRound { get; set; }
        public ICommand AddPlayer { get; set; }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        /* AwaitingPlayerAction implementation -> used to render Player's UI and pause Game execution until PlayerAction is returned */

        public event EventHandler<AwaitingActionEventArgs> PlayerTurn;

        private void OnPlayerTurn(AwaitingActionEventArgs e) {
            EventHandler<AwaitingActionEventArgs> handler = PlayerTurn;
            if (handler != null) {
                handler(this, e);
            }
        }

        /* CancelPlayerAction implementation -> used to hide Player's UI after PlayerAction is returned */

        public event EventHandler<CancelActionEventArgs> CancelTurn;

        private void OnCancelTurn(CancelActionEventArgs e) {
            EventHandler<CancelActionEventArgs> handler = CancelTurn;
            if (handler != null) {
                handler(this, e);
            }
        }

        /* PlayerAction handler */

        public void ReceivePlayerAction(object sender, ReceivedActionEventArgs e) {
            this.pot.handleAction(e.action);
            this.turnInProgress = false;
            OnCancelTurn(new CancelActionEventArgs(this.ActivePlayer));
        }

        /* Class Logic */

        ///// PLAYER POSITIONING /////

        public void assignPositions() {
            Deck d = new Deck(new HashSet<Card>());
            List<Seat> activeSeats = table.getActiveSeats();

            /*foreach(Seat s in activeSeats) {
                Console.WriteLine(s.player.toString());
            }*/

            Seat btn = null;
            Card highest = null;
            foreach (Seat s in activeSeats) {
                Card c = d.getTopCard();
                if (highest == null || (c.highValue > highest.highValue)) {
                    btn = s;
                    highest = c;
                }
            }
            this.btn = btn;

            if (activeSeats.Count == 2) {
                this.sb = this.btn;
            } else if (activeSeats.Count > 2) {
                this.sb = table.getNearestLeftSeatWithActivePlayer(this.btn);
            }

            Console.WriteLine("Button: " + this.btn.player.toString());
            Console.WriteLine("SB: " + this.sb.player.toString());

            this.bb = table.getNearestLeftSeatWithActivePlayer(this.sb);
            this.fp = table.getNearestLeftSeatWithActivePlayer(this.bb);

            Console.WriteLine("BB: " + this.bb.player.toString());
            Console.WriteLine("UTG: " + this.fp.player.toString());
        }

        public void rotatePlayers() {
            this.btn = table.getNearestLeftSeatWithActivePlayer(btn);
            this.sb = table.getNearestLeftSeatWithActivePlayer(sb);
            this.bb = table.getNearestLeftSeatWithActivePlayer(bb);
            this.fp = table.getNearestLeftSeatWithActivePlayer(fp);
        }

        ///// PLAYER HAND GENERATION /////

        public void generateHands(ObservableCollection<Player> activePlayers) {
            //Deck d = new Deck(new HashSet<Card>());
            var hands = new List<List<Card>>() { };

            foreach (int i in Enumerable.Range(0, activePlayers.Count)) {
                hands.Add(new List<Card>());
            }
            foreach (int i in Enumerable.Range(0, 2)) {
                foreach (int n in Enumerable.Range(0, activePlayers.Count)) {
                    hands[n].Add(this.deck.getTopCard());
                }
            }
            foreach (int i in Enumerable.Range(0, activePlayers.Count)) {
                this.dealHand(this.players[i], hands[i]);
            }
        }

        public void dealHand(Player player, List<Card> cards) {
            PreflopHand hand = new HoldemHand(cards);
            player.Hand = hand;
        }

        ///// POSTING BLINDS /////

        public List<Player> postBB(List<Player> activePlayers, Pot pot) {
            Player bb = this.bb.player;
            BetResponse res = bb.removeFromStack(this.bigBlind);
            if (res.complete) {
                Action a = new PostBB(bb, res.amount);
                pot.handleAction(a);
            } else {
                activePlayers.Remove(bb);
                this.bb = table.getNearestLeftSeatWithActivePlayer(this.bb);
                this.fp = table.getNearestLeftSeatWithActivePlayer(this.fp);
                return this.postBB(activePlayers, pot);
            }
            return activePlayers;
        }

        public List<Player> postSB(List<Player> activePlayers, Pot pot) {
            Player sb = this.sb.player;
            BetResponse res = sb.removeFromStack(this.smallBlind);
            if (res.complete) {
                Action a = new PostSB(sb, res.amount);
                pot.handleAction(a);
            } else {
                activePlayers.Remove(sb);
                this.rotatePlayers();
                return this.postSB(activePlayers, pot);
            }
            return activePlayers;
        }

        public List<Player> postAnte(List<Player> activePlayers, Pot pot) {
            foreach (Player p in activePlayers) {
                BetResponse res = p.removeFromStack(this.ante);
                if (res.complete) {
                    Action a = new PostAnte(p, res.amount);
                    pot.handleAction(a);
                } else {
                    activePlayers.Remove(p);
                }
            }
            return activePlayers;
        }

        ///// BOARD GENERATION /////

        public Board generateFlop(Deck deck) {
            deck.getTopCard(); // burned card
            Card c1 = deck.getTopCard();
            Card c2 = deck.getTopCard();
            Card c3 = deck.getTopCard();
            Board b = new Board(c1, c2, c3);
            this.street = Street.FLOP;
            return b;
        }

        public Board generateTurn(Deck deck, Board b) {
            deck.getTopCard(); // burned card
            Card c4 = deck.getTopCard();
            b.setTurn(c4);
            this.street = Street.TURN;
            return b;
        }

        public Board generateRiver(Deck deck, Board b) {
            deck.getTopCard(); // burned card
            Card c5 = deck.getTopCard();
            b.setRiver(c5);
            this.street = Street.RIVER;
            return b;
        }

        ///// PLAYER BETTING /////

        public void preFlopBetting(Pot pot) {
            this.street = Street.PREFLOP;
            Seat ss = this.fp;
            this.bettingRound(ss, pot);
        }

        public void postFlopBetting(Pot pot) {
            Seat ss = this.sb.player.isInHand() ? this.sb : table.getNearestLeftSeatInHand(this.sb);
            this.bettingRound(ss, pot);
        }

        public void bettingRound(Seat startingSeat, Pot pot) {
            while (true) {
                Player p = startingSeat.player;

                GameState gs = this.getState();
                PotState ps = pot.getState(p);

                if (pot.hasActed(p, this.street) && ps.playerContribution == ps.currentBet) {
                    break;
                }

                Action a = p.selectAction(gs, ps);
                pot.handleAction(a);
                startingSeat = table.getNearestLeftSeatInHand(startingSeat);
            }
        }

        ///// GAME LOGIC /////

        public PokerVM() {
            this.bigBlind = 2;
            this.smallBlind = 1;
            this.ante = 0;
            this.maxBuyIn = 200;
            this.minBuyIn = 50;
            this.timePerTurn = 30;
            this.street = Street.FLOP;

            this.players = new ObservableCollection<Player>();
            Account a1 = new Account("Nick", 2000);
            Account a2 = new Account("Matt", 2000);
            Player p1 = new Player(a1, 1000);
            Player p2 = new Player(a2, 1000);

            this.clientPlayer = p1;

            this.registerPlayer(p1);
            this.registerPlayer(p2);

            this.StartRound = new Command(this.startRound, this.canStartRound);
            this.AddPlayer = new Command(this.addPlayer, this.canAddPlayer);
        }

        public void initializeGame() {
            this.assignPositions();
            this.status = GameStatus.RUNNING;
        }

        public void run() {
            while (this.status == GameStatus.RUNNING) {
                List<Player> players = table.getPlayers();
                foreach (Player p in players) {
                    if (p.Stack <= 0 || p.sittingOut) {
                        p.setStatus(PlayerStatus.SITTING_OUT);
                    }
                    if (p.Stack > 0 && !p.sittingOut) {
                        p.setStatus(PlayerStatus.IN_HAND);
                    }
                }
                List<Player> activePlayers = players.Where(p => p.isInHand()).ToList();
                if (!this.areReady(activePlayers)) {
                    this.status = GameStatus.WAITING;
                    Console.WriteLine("Waiting for Players");
                }
                this.startRound(activePlayers);
                this.rotatePlayers(); //will incorrectly rotate players if 'startRound' returns early
            }
            while (this.status == GameStatus.WAITING) {
                Console.WriteLine("Waiting!");
            }
        }

        /*public void startRound(List<Player> activePlayers) {
            Deck d = new Deck(new HashSet<Card>());
            this.pot = new Pot(this.bigBlind);
            this.pot.registerActivePlayers(activePlayers);

            if (this.ante > 0) {
                activePlayers = this.postAnte(activePlayers, this.pot);
            }
            activePlayers = this.postSB(activePlayers, this.pot);
            activePlayers = this.postBB(activePlayers, this.pot);

            if (!this.areReady(activePlayers)) {
                this.status = GameStatus.WAITING;
                return;
            }

            this.generateHands(activePlayers);
            this.preFlopBetting(this.pot);

            if (activePlayers.Count < 2) {
                this.awardPot(this.pot);
            }

            this.board = this.generateFlop(d);
            this.postFlopBetting(this.pot);

            if (activePlayers.Count < 2) {
                this.awardPot(this.pot);
            }

            this.board = this.generateTurn(d, this.board);
            this.postFlopBetting(this.pot);

            if (activePlayers.Count < 2) {
                this.awardPot(this.pot);
            }

            this.board = this.generateRiver(d, this.board);
            this.postFlopBetting(this.pot);

            this.handleEndgame(this.board, this.pot);
        }*/

        public void awardPot(Pot pot) {
            List<Player> players = table.getPlayersToAnalyze();
            if (players.Count == 1) {
                players.First().addToStack(pot.PotSize);
            }
        }

        public void handleEndgame(Board b, Pot pot) {
            List<Player> players = table.getPlayersToAnalyze();
            List<PreflopHand> hands = players.Select(p => p.Hand).ToList();

            WinState ws = PickWinner.determineWinner(b, hands);
            double potShare = pot.PotSize * ws.equity;

            foreach (Player p in players) {
                foreach (BestHand bh in ws.winningHands) {
                    if (bh.hasBestHand(p.Hand, b)) {
                        p.addToStack(potShare);
                    }
                }
            }
        }

        // need to cancel Task if Action/NextRound occurs
        async Task DecrementTimer() {
            await Task.Delay(1000);
            this.TurnTimer -= 1;
            if (this.turnTimer <= 0) {
                this.turnInProgress = false;
                OnCancelTurn(new CancelActionEventArgs(this.ActivePlayer));
            }
        }

        public async void bettingRound() {
            foreach (Player p in this.players) {
                this.ActivePlayer = p;
                this.TurnTimer = 30;
                this.turnInProgress = true;
                OnPlayerTurn(new AwaitingActionEventArgs(this.getState(), pot.getState(ActivePlayer), ActivePlayer));
                while (turnInProgress) {
                    await this.DecrementTimer();
                }
            }
        }


        public void registerPlayer(Player p) {
            this.players.Add(p); // temp

            Seat emptySeat;
            try {
                emptySeat = this.table.getEmptySeat();
            } catch (NoValidSeatException e) {
                Console.WriteLine("Unable to register player. There are no empty seats.");
                // add code to add player to waitlist
                return;
            }
            emptySeat.setPlayer(p);

            // register events
            this.PlayerTurn += p.AwaitPlayerAction;
            this.CancelTurn += p.CancelPlayerAction;
            p.PlayerAction += this.ReceivePlayerAction;
        }


        // used to determine if User UI should be rendered (e.g. only on client-registered player's turn)
        private bool isClientPlayerActive() {
            return this.clientPlayer == this.activePlayer;
        }

        // used to determine if StartRound can be called
        private bool areReady(List<Player> activePlayers) {
            int readyCount = activePlayers.Count;
            return readyCount >= 2 ? true : false;
        }

        public GameState getState() {
            return new GameState(street, ante, smallBlind, bigBlind, maxBuyIn, minBuyIn, timePerTurn);
        }


        /* Command Implementation */

        private bool canStartRound(object e) {
            //return this.players.Count >= 2;
            return true;
        }

        private void startRound(object e) {
            this.Pot = new Pot(this.bigBlind);
            pot.registerActivePlayers(new List<Player>(this.players));
            this.deck = new Deck(new HashSet<Card>());
            this.generateHands(this.players);
            this.Board = new Board(deck.getTopCard(), deck.getTopCard(), deck.getTopCard());

            this.clientPlayer.showHand();
            this.bettingRound();

            Debug.WriteLine("Round Over");
        }

        private bool canAddPlayer(object e) {
            return this.players.Count <= 9;
        }

        private void addPlayer(object e) {
            using (var context = new AccountContext()) {
                var accounts = context.accounts.ToList();

            }
        }
    }
}
