using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
    public class Deck {
        public HashSet<Card> cards { get; private set; }
        public int length { get; private set; }
        
        public Deck(HashSet<Card> deadCards, bool generateHands=false) {
            this.cards = Data.getDeck();
            this.cards.ExceptWith(deadCards);
            this.cards = FisherYates.shuffle(this.cards);
            this.length = this.cards.Count(); 
        }

        //////////// CLASS LOGIC ////////////

        public void removeDeadCards(HashSet<Card> deadCards) {
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

        public List<Card> getCardsBySuit(Suit s) {
            var filtered = cards.Where(c => c.suit == s);
            return filtered.ToList();
        }

        public List<Card> getCardsByType(CardType ct) {
            var filtered = cards.Where(c => c.type == ct);
            return filtered.ToList();
        }

        public List<Card> getPreflopHands() {
            throw new NotImplementedException();
        }

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
