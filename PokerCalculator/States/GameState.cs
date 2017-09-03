using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class GameState {
        public Street street { get; }
        public double ante { get; }
        public double sb { get; }
        public double bb { get; }
        public double maxBuyIn { get; }
        public double minBuyIn { get; }
        public double timer { get; }

        public GameState(Street street, double ante, double sb, double bb, double maxBuyIn, double minBuyIn, double timer) {
            this.street = street;
            this.ante = ante;
            this.sb = sb;
            this.bb = bb;
            this.maxBuyIn = maxBuyIn;
            this.minBuyIn = minBuyIn;
            this.timer = timer;
        }
    }
}
