using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Deck {
        public HashSet<Card> cards { get; private set; }
        public int length { get; private set; }
        public Dictionary<string, List<PreflopHand>> preflopHands { get; private set; }

        public Deck(List<Card> deadCards, bool generateHands) {


        }

        //////////// CLASS LOGIC ////////////


        public void suffleDeck() {
            cards = Deck.shuffle(this.cards);
        }

        static List<Card> shuffle(List<Card> cards) {
            List<Card> ary = cards;
            int a = ary.Count();
            int b = a - 1;

            foreach(int d in ???) {

            }
            return ary;
        }

        public void resetDeck() {

        }

        public void removeDeadCards(List<Card> deadCards) {
            
        }

        public Card getTopCard() {
            Card c = cards.First();
            cards.Remove(c);
            length--;
            return c;
        }


        //////////// GETTERS AND SETTERS ////////////



        //////////// UTILITY METHODS ////////////

        public string toString() {
            string rep = "";
            foreach (Card c in this.cards) {
                rep += c.toString();
            }
            return rep;
        }

        public void checkRep() {
            //assert length <= 52 and length >= 0
        }


    }
}
