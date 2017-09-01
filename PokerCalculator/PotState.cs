using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class PotState {
        public double pot { get; }
        public double currentBet { get; }
        public double playerContribution { get; }

        public PotState(double pot, double currentBet, double contribution) {
            this.pot = pot;
            this.currentBet = currentBet;
            this.playerContribution = contribution;
        }

    }
}
