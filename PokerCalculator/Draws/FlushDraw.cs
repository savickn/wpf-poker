using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class FlushDraw : Draw {
        public FlushDraw(List<Card> outs) : base("Flush", outs) {

        }

        public static List<Card> calculateOuts(List<Card> cards) {
            var set = new HashSet<Card>(cards);
            var suit = cards[0].suit;
            var outs = Data.getCardsBySuit(suit);
            outs.ExceptWith(set);
            return new List<Card>(outs);
        }

        public bool isNut() {
            throw new NotImplementedException();
        }

        public new void checkRep() {
            base.checkRep();
            //more checks
        }
    }
}
