using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Flush : Hand {

        public Flush(List<Card> cards) : base(cards, cards.Max(c => c.highValue), "F") {

        }

        ////// CLASS LOGIC //////

        public override int handComp<Flush>(Flush other) {
            using (var e1 = cards.GetEnumerator())
            using (var e2 = other.cards.GetEnumerator()) {
                while (e1.MoveNext() && e2.MoveNext()) {
                    var c1 = e1.Current;
                    var c2 = e2.Current;
                    
                    if(c1 > c2 == c1) {
                        return 1;
                    } else if(c2 > c1 == c2) {
                        return -1;
                    } else {
                        continue;
                    }
                }
                return 0;
            }
        }

        ////// UTILITY METHODS //////

        public new void checkRep() {
            base.checkRep();

        }

        public new string toString() {
            return "";
        }
    }
}
