using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PokerCalculator {
    public class Board : INotifyPropertyChanged {

        public ObservableCollection<Card> Cards {
            get { return new ObservableCollection<Card>(this.getCards()); }
        }

        private Card flop1;
        private Card flop2;
        private Card flop3;
        private Card turn;
        private Card river;

        public Card F1 {
            get { return flop1; }
            set { flop1 = value; OnPropertyChanged("F1"); }
        }

        public Card F2 {
            get { return flop2; }
            set { flop2 = value; OnPropertyChanged("F2"); }
        }

        public Card F3 {
            get { return flop3; }
            set { flop3 = value; OnPropertyChanged("F3"); }
        }

        public Card Turn {
            get { return turn != null ? turn : null; }
            set { turn = value; OnPropertyChanged("Turn"); }
        }

        public Card River {
            get { return river != null ? river : null; }
            set { river = value; OnPropertyChanged("River"); }
        }

        ///// INotify Implementation /////

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        public Board(Card card1, Card card2, Card card3, Card card4 = null, Card card5 = null) {
            this.flop1 = card1;
            this.flop2 = card2;
            this.flop3 = card3;
            this.turn = card4;
            this.river = card5;

            F1.Hidden = false;
            F2.Hidden = false;
            F3.Hidden = false;

            //this.cards = new ObservableCollection<Card>() { card1, card2, card3 };
        }

        //takes a Deck obj and a list of existing cards and returns a completed Board object
        public static Board generateBoard(Deck deck, Board board=null) {
            Board b = board;
            if (b == null) {
                deck.getTopCard(); // burn card
                b = new Board(deck.getTopCard(), deck.getTopCard(), deck.getTopCard());
            }
            if (b.getCards().Count == 3) {
                deck.getTopCard(); // burn card
                b.setTurn(deck.getTopCard());
            }
            if (b.getCards().Count == 4) {
                deck.getTopCard(); // burn card
                b.setRiver(deck.getTopCard());
            }
            return b;
         }

        //////////// GETTERS AND SETTERS ////////////

        public List<Card> getCards() {
            var board = new List<Card>() { this.flop1, this.flop2, this.flop3 };
            if (this.turn != null) {
                board.Add(this.turn);
                if(this.river != null) {
                    board.Add(this.river);
                }
            }
            return board;
        }

        public void setTurn(Card turn) {
            Turn = turn;
            Turn.Hidden = false;
            //this.cards.Add(turn);
            //assert len(self.getCards()) is 4
        }

        public void setRiver(Card river) {
            River = river;
            River.Hidden = false;
            //this.cards.Add(river);
            //assert len(self.getCards()) is 5
        }

        //////////////// UTILITY METHODS /////////////////

        public string toString() {
            string rep = "Board: ";
            foreach (Card c in getCards()) {
                rep += String.Format("{0} ,", c.toString());
            };
            return rep;
        }

        public void checkRep() {
            //assert self.getCards() in range(3, 6);
        }
    }
}
