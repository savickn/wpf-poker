using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Draw {
        public string name { get; } // e.g. Flush, Gutshot, etc
        public string type { get; } // e.g. P/T/Q/etc
        public List<Card> outs { get; } 

        public Draw(string name, string type, List<Card> outs) {
            this.name = name;
            this.type = type;
            this.outs = outs;
        }

        //public bool compare

        public int getHandRanking() {
            return Data.getHandRanking(type);
        }

        public int getDrawRanking() {
            return Data.getDrawRanking(name);
        }

        public void toString() {

        }

        public void checkRep() {

        }

    }
}
