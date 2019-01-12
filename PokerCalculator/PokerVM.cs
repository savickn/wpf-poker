using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    public class PokerVM : INotifyPropertyChanged {

        /* Properties */

        public string newPlayer { get; set; }
        public bool turnInProgress { get; private set; }
        public bool gameStatus { get; private set; }

        private Deck deck;
        private Board board;
        private Pot pot;
        private Player activePlayer;

        public ObservableCollection<Player> players { get; set; }

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
        }


        public PokerVM() {
            this.players = new ObservableCollection<Player>();
            this.registerPlayer(new Player("Nick", 1000));
            this.registerPlayer(new Player("Matt", 1000));

            this.StartRound = new Command(this.startRound, this.canStartRound);
            this.AddPlayer = new Command(this.addPlayer, this.canAddPlayer);
        }

        /* Command Implementation */

        private bool canStartRound(object e) {
            //return this.players.Count >= 2;
            return true;
        }

        private void startRound(object e) {
            this.Pot = new Pot(2);
            pot.registerActivePlayers(new List<Player>(this.players));
            this.deck = new Deck(new HashSet<Card>());
            this.generateHands(this.players);
            this.Board = new Board(deck.getTopCard(), deck.getTopCard(), deck.getTopCard());

            this.bettingRound();

            Debug.WriteLine("Round Over");
        }

        private bool canAddPlayer(object e) {
            return this.players.Count <= 9;
        }

        private void addPlayer(object e) {
            using (var context = new PlayerContext()) {
                var players = context.Players.ToList();

            }
        }

        /* Class Logic */

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

        public void registerPlayer(Player p) {
            this.players.Add(p);
            this.PlayerTurn += p.AwaitPlayerAction;
            this.CancelTurn += p.CancelPlayerAction;
            p.PlayerAction += this.ReceivePlayerAction;
        }

        async Task PutTaskDelay() {
            await Task.Delay(100);
        }

        public async void bettingRound() {
            foreach (Player p in this.players) {
                this.ActivePlayer = p;
                this.turnInProgress = true;
                while (turnInProgress) {
                    await this.PutTaskDelay();
                }
            }
        }

        /*public GameState getState() {
            return new GameState(street, ante, smallBlind, bigBlind, maxBuyIn, minBuyIn, timer);
        }*/

    }
}
