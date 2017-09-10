using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class ThreeOfAKind : Hand {

        public ThreeOfAKind(List<Card> cards) : base(cards, cards[0].highValue, "T") {

        }

        public override int handComp<ThreeOfAKind>(ThreeOfAKind other) {
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
            return String.Format("ThreeOfAKind: {0}", base.toString());
        }

        public new void checkRep() {

        }
    }
}
