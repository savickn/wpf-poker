using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Pair : Hand {

        public Pair() : base() {

        }

        public int compare(Pair other) {

        }

        /////// UTILITY METHODS ///////

        public string toString() {
            return String.Format("Pair: {0}", base.toString());
        }

        public void checkRep() {

        }
    }
}
