using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class FourOfAKind : Hand {

        public FourOfAKind(List<Card> cards) : base(cards, cards[0].highValue, "Q") {

        }


        public int compare(FourOfAKind other) {
            int prefixComparison = comparePrefixes(this, other);
            if (prefixComparison == 1 || prefixComparison == -1) {
                return prefixComparison;
            } else {
                if (this.primaryValue > other.primaryValue) {
                    return 1;
                } else if (this.primaryValue < other.primaryValue) {
                    return -1;
                } else {
                    return 0;
                }
            }
        }

        /////// UTILITY METHODS ///////

        public string toString() {
            return String.Format("FourOfAKind: {0}", base.toString());
        }

        public void checkRep() {

        }

    }
}
