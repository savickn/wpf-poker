using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PokerCalculator {

    /*
     * Only requires ObservableCollection
     */

    public abstract class PreflopHand {
        public ObservableCollection<Card> cards;
        public int length { get; private set; }

        public PreflopHand(List<Card> cards, int length) {
            this.cards = new ObservableCollection<Card>(cards);
            this.length = length;
        }

        ///// UTILITY METHODS /////

        public string toString() {
            return String.Format("Preflop Hand: {0}", cards);
        }
    }

    public class HoldemHand : PreflopHand {

        public HoldemHand(List<Card> cards) : base(cards, 2) {}

        public bool isSuited() {
            var cards = base.cards;
            return cards[0].suit == cards[1].suit ? true : false;
        }

        public bool isPaired() {
            var cards = base.cards;
            return cards[0].highValue == cards[1].highValue ? true : false;
        }

        public string getInitials() {
            var str = cards[0].initial + cards[1].initial;
            str += isSuited() ? "s" : "o";
            return str;
        }
    }

    public class OmahaHand : PreflopHand {

        public OmahaHand(List<Card> cards) : base(cards, 2) {

        }

    }

    class StudHand : PreflopHand {

        public StudHand(List<Card> cards) : base(cards, 3) {

        }
    }
}
