using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Pair : Hand {

        public Pair(List<Card> cards, int value) : base(cards, value, "P") {

        }

        public override int handComp<Pair>(Pair other) {
            if (this.value > other.value) {
                return 1;
            } else if (this.value < other.value) {
                return -1;
            } else {
                return 0;
            }
        }

        /////// UTILITY METHODS ///////

        public new string toString() {
            return String.Format("Pair: {0}", base.toString());
        }

        public new void checkRep() {

        }
    }
}
