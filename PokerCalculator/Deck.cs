using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Deck {
        public List<Card> cards { get; private set; }
        public int length { get; private set; }
        public Dictionary<string, List<PreflopHand>> preflopHands { get; private set; }

        public Deck(List<Card> deadCards, bool generateHands) {


        }

        //////////// CLASS LOGIC ////////////

        public void resetDeck() {
            throw new NotImplementedException();
        }

        public void removeDeadCards(List<Card> deadCards) {
            foreach(Card c in deadCards) {
                if(cards.Contains(c)) {
                    cards.Remove(c);
                }
            }
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
