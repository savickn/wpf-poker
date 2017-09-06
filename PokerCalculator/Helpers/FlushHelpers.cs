using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class FlushHelpers {
        public static bool isSameSuit(List<Card> cards) {
            Suit s = cards[0].suit;
            foreach(Card c in cards) {
                if(c.suit != s) {
                    return false;
                }
            }
            return true;
        }

        public static bool isFlush(List<Card> cards) {
            return cards.Count >= 5 && FlushHelpers.isSameSuit(cards) ? true : false;
        }

        public static bool isFlushDraw(List<Card> cards) {
            return cards.Count == 4 && FlushHelpers.isSameSuit(cards) ? true : false;
        }

        public static bool isBackdoorFlushDraw(List<Card> cards) {
            return cards.Count == 3 && FlushHelpers.isSameSuit(cards) ? true : false;
        }
    }
}
