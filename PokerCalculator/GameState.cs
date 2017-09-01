using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class GameState {
        public double ante { get; private set; }
        public double sb { get; private set; }
        public double bb { get; private set; }
        public double maxBuyIn { get; private set; }
        public double minBuyIn { get; private set; }
        public double timer { get; private set; }

        public GameState(double ante, double sb, double bb, double maxBuyIn, double minBuyIn, double timer) {
            this.ante = ante;
            this.sb = sb;
            this.bb = bb;
            this.maxBuyIn = maxBuyIn;
            this.minBuyIn = minBuyIn;
            this.timer = timer;
        }
    }
}
