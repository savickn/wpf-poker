using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class TwoPair : Hand {
        public TwoPair(Pair highPair, Pair lowPair) : base(highPair.cards.Concat(lowPair.cards).ToList(), highPair.value, "P", lowPair.value) {
        }

        public override int handComp<TwoPair>(TwoPair other) {
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
            return String.Format("Pair: {0}", base.toString());
        }

        public new void checkRep() {

        }


    }
}
