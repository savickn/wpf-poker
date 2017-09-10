using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class FullHouse : Hand {
        public FullHouse(ThreeOfAKind t, Pair p) : base (t.cards.Concat(p.cards).ToList(), t.value, "B", p.value) {

        }

        public override int handComp<FullHouse>(FullHouse other) {
            if (this.value > other.value) {
                return 1;
            } else if (this.value < other.value) {
                return -1;
            } else {
                if(this.secondary > other.secondary) {
                    return 1;
                } else if(this.secondary < other.secondary) {
                    return -1;
                } else {
                    return 0;
                }
            }
        }

        /////// UTILITY METHODS ///////

        public new string toString() {
            return String.Format("FullHouse: {0}", base.toString());
        }

        public new void checkRep() {

        }

    }
}
