using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Deck {
        public HashSet<Card> cards { get; private set; }
        public int length { get; private set; }
        public Dictionary<string, List<HoldemHand>> holdemHands { get; private set; }

        public Deck(HashSet<Card> deadCards, bool generateHands=false) {
            this.cards = Data.getDeck();
            this.cards.ExceptWith(deadCards);
            this.cards = FisherYates.shuffle(this.cards);
            this.length = this.cards.Count(); 
            this.holdemHands = generateHands ? generateHoldemHandCombos(cards) : new Dictionary<string, List<HoldemHand>>();
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

        //////////// COMBINATORICS ////////////

        public Dictionary<string, List<HoldemHand>> generateHoldemHandCombos(HashSet<Card> liveCards, bool toPrint=false) {
            var processed = new List<Card>();
            var hands = new List<HoldemHand>();

            foreach(Card c1 in liveCards) {
                foreach(Card c2 in liveCards) {
                    if(c1 != c2 && !processed.Contains(c2)) {
                        var pHand = new HoldemHand(new List<Card>() { c1, c2 });
                        if(!hands.Contains(pHand)) {
                            hands.Add(pHand);
                        }
                    }
                }
                processed.Add(c1);
            }

            foreach(HoldemHand h in hands) {
                if(holdemHands.Keys.Contains(h.getInitials())) {
                    holdemHands[h.getInitials()].Add(h);
                } else {
                    holdemHands[h.getInitials()] = new List<HoldemHand>();
                }
            }

            if(toPrint) {
                Console.WriteLine("#### HAND TYPES ####");
                foreach(string k in holdemHands.Keys) {
                    var length = holdemHands[k].Count;
                    Console.WriteLine(String.Format("{0} - {1}", k, length));
                }
            }
            return holdemHands;
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
