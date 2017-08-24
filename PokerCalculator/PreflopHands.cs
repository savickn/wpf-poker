using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    abstract class PreflopHand {
        List<Card> cards;
        int length;

        public PreflopHand(List<Card> cards, int length) {
            this.cards = cards;
            this.length = length;
        }

        public List<Card> getCards() {
            return cards;
        }

        
    }

    class HoldemHand : PreflopHand {

        public HoldemHand(List<Card> cards) : base(cards, 2) {
            
        }

        public bool isSuited() {
            var cards = getCards();
            return cards[0].getSuit() == cards[1].getSuit() ? true : false;
        }

        public bool isPaired() {

        }

        public string getInitials() {

        }
    }

    class OmahaHand : PreflopHand {

        public OmahaHand(List<Card> cards) : base(cards, 2) {

        }

    }

    class StudHand : PreflopHand {

        public StudHand(List<Card> cards) : base(cards, 3) {

        }
    }
}
