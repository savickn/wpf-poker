using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Deck {
        private List<Card> cards;
        private int length;
        //preflopHands

        public Deck(List<Card> deadCards, bool generateHands) {


        }

        public string toString() {
            string rep = "";
            foreach(Card c in this.cards) {
                rep += c.toString();
            }
            return rep;
        }

        public void suffleDeck() {
            this.cards = Deck.shuffle(this.cards);
        }

        static List<Card> shuffle(List<Card> cards) {
            List<Card> ary = cards;
            int a = ary.Count();
            int b = a - 1;

            foreach(int d in ???) {

            }
            return ary;
        }

        public void removeDeadCards(List<Card> deadCards) {
            
        }



    }
}
