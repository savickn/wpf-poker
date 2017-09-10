using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    abstract class Draw {
        //public string name { get; } // e.g. Flush, Gutshot, etc
        public string type { get; }
        public List<Card> cards { get; }
        public List<Card> outs { get; } 

        public Draw(string type, List<Card> cards, List<Card> outs) {
            this.type = type;
            this.cards = cards;
            this.outs = outs;
        }

        public int compare(Draw other) {
            if(this.getDrawRanking() > other.getDrawRanking()) {
                return 1;
            } else if(this.getDrawRanking() < other.getDrawRanking()) {
                return -1;
            } else {
                return 0;
            }
        }

        /*public int getHandRanking() {
            return Data.getHandRanking(type);
        }*/

        public int getDrawRanking() {
            return Data.getDrawRanking(type);
        }

        public string toString() {
            throw new NotImplementedException();
        }

        public void checkRep() {

        }

    }
}
