using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class BetResponse {
        public double amount { get; }
        public bool complete { get; }

        public BetResponse(double amount, bool complete) {
            this.amount = amount;
            this.complete = complete;
        }

    }
}
