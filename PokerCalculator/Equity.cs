using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Equity {
        public PreflopHand hand { get; }
        public int count { get; private set; }
        private double aggregate;

        public Equity(PreflopHand pf) {
            this.hand = pf;
            this.count = 0;
            this.aggregate = 0;
        }

        public double getEquity() {
            return count > 0 ? aggregate/count : 0; 
        }

        public void updateEquity(double eq) {
            aggregate += eq;
            count += 1;
        }

        ////// UTILITY METHODS //////

        public string toString() {
            throw new NotImplementedException();
        }
    }
}
