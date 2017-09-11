using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class GutshotDraw : Draw {
        public GutshotDraw(List<Card> outs) : base("Gutshot", outs) {

        }

        public new void checkRep() {
            base.checkRep();
            // assert length == 4
        }

    }
}
