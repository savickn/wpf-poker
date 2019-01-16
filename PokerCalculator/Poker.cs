using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PokerCalculator {
    public class Poker : INotifyPropertyChanged {
        /*public GameStatus status {
            get { return this.status; }
            set {
                if(value != this.status) {
                    this.status = value;
                    NotifyPropertyChanged("status");
                }
            }
        }
        public Street street {
            get { return this.street; }
            set {
                if (value != this.street) {
                    this.street = value;
                    NotifyPropertyChanged("street");
                }
            }
        }*/
        public GameStatus status { get; private set; }
        public Street street { get; private set; }
        public Table table { get; }
        public Player activePlayer { get; }
        public Player userAccount { get; }

        public Pot pot { get; private set; } = null;
        public Board board { get; private set; } = null;

        //private Deck deck { get; }

        /*public Seat btn {
            get { return this.btn; }
            set {
                if(value != this.btn) {
                    this.btn = value;
                    NotifyPropertyChanged("btn");
                }
            }
        }*/

        public Seat btn { get; private set; }
        public Seat sb { get; private set; }
        public Seat bb { get; private set; }
        public Seat fp { get; private set; }

        public double bigBlind { get; }
        public double smallBlind { get; }
        public double ante { get; }
        public double maxBuyIn { get; }
        public double minBuyIn { get; }
        public int cardsPerHand { get; }

        public double timer { get; }

        /*Player playerToAct;
        int currentBet;
        int minRaise;
        int maxBet;*/

        /*bool isPreflop;
        bool isHeadsUp;*/

        public Poker(Table t, GameOptions go) {
            this.cardsPerHand = go.cardsPerHand;
            this.bigBlind = go.bb;
            this.smallBlind = go.sb;
            this.ante = go.ante;
            this.maxBuyIn = go.maxBuyIn;
            this.minBuyIn = go.minBuyIn;
            this.timer = go.timer;

            //this.table = new Table(go.numberOfSeats);
            this.table = t;
        }

        ///// EVENT HANDLERS /////

        // 'sender' should be the 'Player' that emitted the event
        // 'e' should contain type of Action + amount/etc
        /*public void handlePlayerAction(object sender, PlayerActionArgs e) {
            if(activePlayer != sender) {
                e.Handled = true;
                return;
            }
            if(e.type == Fold) {
                //handle Fold
            } else if (e.type == Call) {
                //handle Call
            } else if (e.type == Raise) {
                //handle Raise
            } else {
                //handle Check
            }
        }*/

        ///// Interface Implementation /////

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

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

            if(activeSeats.Count == 2) {
                this.sb = this.btn;
            } else if(activeSeats.Count > 2) {
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

        public void generateHands(List<Player> activePlayers) {
            Deck d = new Deck(new HashSet<Card>());
            var hands = new List<List<Card>>() {
                
            };
            foreach(int i in Enumerable.Range(0, activePlayers.Count)) {
                hands.Add(new List<Card>());
            }
            foreach(int i in Enumerable.Range(0, this.cardsPerHand)) {
                foreach(int n in Enumerable.Range(0, activePlayers.Count)) {
                    hands[n].Add(d.getTopCard());
                }
            }
            Seat s = this.sb;
            foreach(int i in Enumerable.Range(0, activePlayers.Count)) {
                this.dealHand(s.player, hands[i]);
                s = table.getNearestLeftSeatWithActivePlayer(s);
            }
        }

        public void dealHand(Player player, List<Card> cards) {
            PreflopHand hand = new HoldemHand(cards);
            player.setHand(hand);
        }

        ///// POSTING BLINDS /////

        public List<Player> postBB(List<Player> activePlayers, Pot pot) {
            Player bb = this.bb.player;
            BetResponse res = bb.removeFromStack(this.bigBlind);
            if(res.complete) {
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
            if(res.complete) {
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
            foreach(Player p in activePlayers) {
                BetResponse res = p.removeFromStack(this.ante);
                if(res.complete) {
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
            deck.getTopCard(); // burned cards
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
            while(true) {
                Player p = startingSeat.player;

                GameState gs = this.getState();
                PotState ps = pot.getState(p);

                if (pot.hasActed(p, this.street) && ps.playerContribution == ps.currentBet) {
                    break;
                }

                //Action a = p.selectAction(gs, ps);
                //pot.handleAction(a);
                startingSeat = table.getNearestLeftSeatInHand(startingSeat);
            }
        }

        ///// GAME LOGIC /////

        public void initializeGame() {
            this.assignPositions();
            this.status = GameStatus.RUNNING;
        }

        public void run() {
            while(this.status == GameStatus.RUNNING) {
                List<Player> players = table.getPlayers();
                foreach(Player p in players) {
                    if(p.Stack <= 0 || p.sittingOut) {
                        p.setStatus(PlayerStatus.SITTING_OUT);
                    }
                    if(p.Stack > 0 && !p.sittingOut) {
                        p.setStatus(PlayerStatus.IN_HAND);
                    }
                }
                List<Player> activePlayers = players.Where(p => p.isInHand()).ToList();
                if(!this.areReady(activePlayers)) {
                    this.status = GameStatus.WAITING;
                    Console.WriteLine("Waiting for Players");
                }
                this.startRound(activePlayers);
                this.rotatePlayers(); //will incorrectly rotate players if 'startRound' returns early
            }
            while(this.status == GameStatus.WAITING) {
                Console.WriteLine("Waiting!");
            }
        }

        public void startRound(List<Player> activePlayers) {
            Deck d = new Deck(new HashSet<Card>());
            this.pot = new Pot(this.bigBlind);
            this.pot.registerActivePlayers(activePlayers);

            if(this.ante > 0) {
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

            if(activePlayers.Count < 2) {
                this.awardPot(this.pot);
            }

            this.board = this.generateTurn(d, this.board);
            this.postFlopBetting(this.pot);

            if(activePlayers.Count < 2) {
                this.awardPot(this.pot);
            }

            this.board = this.generateRiver(d, this.board);
            this.postFlopBetting(this.pot);

            this.handleEndgame(this.board, this.pot);
        }

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

            foreach(Player p in players) {
                foreach(BestHand bh in ws.winningHands) {
                    if(bh.hasBestHand(p.Hand, b)) {
                        p.addToStack(potShare);
                    }
                }
            }
        }

        ///// GAME STATE MANAGER /////

        public bool areReady(List<Player> activePlayers) {
            int readyCount = activePlayers.Count;
            return readyCount >= 2 ? true : false;
        }

        public void registerPlayer(Player p) {
            Seat emptySeat;
            try {
                emptySeat = this.table.getEmptySeat();
            } catch (NoValidSeatException e) {
                Console.WriteLine("Unable to register player. There are no empty seats.");
                // add code to add player to waitlist
                return;
            }
            emptySeat.setPlayer(p);
        }

        public void findPlayer(int id) {

        }

        ///// GETTERS & SETTERS /////

        public GameState getState() {
            return new GameState(street, ante, smallBlind, bigBlind, maxBuyIn, minBuyIn, timer);
        }

        ///// UTILITY METHODS /////

        public string toString() {
            throw new NotImplementedException();
        }
    }
}
