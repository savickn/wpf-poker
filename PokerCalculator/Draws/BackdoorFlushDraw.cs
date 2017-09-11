using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class BackdoorFlushDraw : Draw {
        public BackdoorFlushDraw(List<Card> outs) : base("BackdoorFD", outs) {

        }

    }
}
