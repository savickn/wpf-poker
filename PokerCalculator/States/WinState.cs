using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class WinState {
        public double equity { get; }
        public List<BestHand> winningHands { get; }

        public WinState(double eq, List<BestHand> wh) {
            equity = eq;
            winningHands = wh;
        }
    }
}
