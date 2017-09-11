using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class StraightHelpers {
        public static Suit getRelevantSuit(List<Card> cards) {
            int spades = 0;
            int clubs = 0;
            int hearts = 0;
            int diamonds = 0;

            foreach(Card c in cards) {
                if(c.suit == Suit.CLUBS) {
                    clubs += 1;
                } else if(c.suit == Suit.DIAMONDS) {
                    diamonds += 1;
                } else if(c.suit == Suit.HEARTS) {
                    hearts += 1;
                } else if(c.suit == Suit.SPADES) {
                    spades += 1;
                } else {
                    throw new Exception();
                }
            }
            if(spades >= hearts && spades >= clubs && spades >= diamonds) {
                return Suit.SPADES;
            } else if(clubs >= hearts && clubs >= diamonds && clubs >= spades) {
                return Suit.CLUBS;
            } else if(diamonds >= clubs && diamonds >= spades && diamonds >= hearts) {
                return Suit.DIAMONDS;
            } else {
                return Suit.HEARTS;
            }
        }

        public static HashSet<Card> removePairs(List<Card> cards, Suit suit) {
            var filtered = new HashSet<Card>();
            foreach (Card c in cards) {
                if(c.suit == suit) {
                    filtered.Add(c);
                }
            }
            foreach(Card c in cards) {
                if(filtered.Contains(c)) {
                    continue;
                }
                bool isPaired = false;
                foreach(Card c2 in filtered) {
                    if(c.highValue == c2.highValue) {
                        isPaired = true;
                        break;
                    }
                }
                if(!isPaired) {
                    filtered.Add(c);
                }
            }
            return filtered;
        }

        public static bool isStraight(List<Card> availableCards) {
            Suit suit = StraightHelpers.getRelevantSuit(availableCards);
            HashSet<Card> cards = StraightHelpers.removePairs(availableCards, suit);
            if(cards.Count < 5) {
                return false;
            }
            int highDist = cards.Max(c => c.highValue) - cards.Min(c => c.highValue);
            int lowDist = cards.Max(c => c.lowValue) - cards.Min(c => c.lowValue);
            return highDist == 4 || lowDist == 4 ? true : false;
        }
        
        public static void analyzeStraights(List<Card> cards) {
            int maxHigh = cards.Max(c => c.highValue);
            int minLow = cards.Min(c => c.lowValue);
            int highDist = maxHigh - cards.Min(c => c.highValue);
            int lowDist = cards.Max(c => c.lowValue) - minLow;
            int length = cards.Count;

            if(length == 4) {
                if(highDist == 4 || lowDist == 4) {
                    //create gutshot
                } else if(highDist == 3) {
                    if(maxHigh == 14) {
                        //create gutshot
                    } else {
                        //create open ender
                    }
                } else if(lowDist == 3) {
                    if(minLow == 1) {
                        //create gutshot
                    } else {
                        //create open ender
                    }
                } else {
                    return;
                }
            } else {
                return;
            }
        }


    }
}
