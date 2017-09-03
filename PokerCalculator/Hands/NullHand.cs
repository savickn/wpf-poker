using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class NullHand : Hand {
        public NullHand() : base(new List<Card>(), 0, "N") {

        }

        public override int handComp<NullHand>(NullHand other) {
            return 0;
        }

        //////// UTILITY METHODS ////////

        public new string toString() {
            throw new NotImplementedException();
        }

    }
}
