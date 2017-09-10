using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class StraightFlush : Hand {

        public StraightFlush(List<Card> cards) : base(cards, cards.Max(c => c.highValue), "Z") {

        }

        public override int handComp<StraightFlush>(StraightFlush other) {
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
