using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class ThreeOfAKind : Hand {

        public ThreeOfAKind() : base() {

        }

        public int compare(ThreeOfAKind other) {
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
        }

        /////// UTILITY METHODS ///////

        public string toString() {
            return String.Format("ThreeOfAKind: {0}", base.toString());
        }

        public void checkRep() {

        }
    }
}
