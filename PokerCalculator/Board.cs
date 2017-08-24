using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Board {
        private Card flop1;
        private Card flop2;
        private Card flop3;
        private Card turn;
        private Card river;

        public Board(Card card1, Card card2, Card card3, Card card4 = null, Card card5 = null) {
            this.flop1 = card1;
            this.flop2 = card2;
            this.flop3 = card3;
            this.turn = card4;
            this.river = card5;
        }

        public string toString() {
            string rep = "Board: ";
            foreach (Card c in getCards()) {
                rep += String.Format("{0} ,", c.toString());
            };
            return rep;
        }

        //takes a Deck obj and a list of existing cards and returns a completed Board object
        static Board generateBoard(Deck deck, Board board) {
            Board b = new Board(*board);
            if (b == null) {
                deck.getTopCard();
                b = new Board(deck.getTopCard(), deck.getTopCard(), deck.getTopCard());
            }
            if (b.getCards().length == 3) {
                deck.getTopCard();
                b.setTurn(deck.getTopCard());
            }
            if len(b.getCards()) == 4 {
                deck.getTopCard();
                b.setRiver(deck.getTopCard());
            }
            return b;
         }

        //////////// GETTERS AND SETTERS ////////////

        public List<Card> getCards() {
            List<Card> board = [this.flop1, this.flop2, this.flop3];
            if (this.turn != null) {
                board.Add(this.turn);
                if(this.river != null) {
                    board.Add(this.river);
                }
            }
            return board;
        }

        public void setTurn(Card turn) {
            this.turn = turn;
            //assert len(self.getCards()) is 4
        }

        public void setRiver(Card river) {
            this.river = river;
            //assert len(self.getCards()) is 5
        }

        //////////////// UTILITY METHODS /////////////////

        public void draw() {
            foreach (Card c in this.getCards()) {
                c.draw();
            }
        }

        //public void checkRep() {
        //    assert self.getCards() in range(3, 6);
        //}
    }
}
