using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class FourOfAKind : Hand {

        public FourOfAKind(List<Card> cards, int value) : base(cards, value, "Q") {

        }

        public override int handComp<FourOfAKind>(FourOfAKind other) {
            if (this.value > other.value) {
                return 1;
            } else if (this.value < other.value) {
                return -1;
            } else {
                return 0;
            }
        }

        /*public int compare(FourOfAKind other) {
            int prefixComparison = comparePrefixes(this, other);
            if (prefixComparison == 1 || prefixComparison == -1) {
                return prefixComparison;
            } else {
                if (this.value > other.value) {
                    return 1;
                } else if (this.value < other.value) {
                    return -1;
                } else {
                    return 0;
                }
            }
        }*/

        /////// UTILITY METHODS ///////

        public new string toString() {
            return String.Format("FourOfAKind: {0}", base.toString());
        }

        public new void checkRep() {

        }

    }
}
