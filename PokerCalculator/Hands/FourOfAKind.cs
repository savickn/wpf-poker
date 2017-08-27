using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class FourOfAKind : Hand {

        public FourOfAKind(List<Card> cards) : base(cards, cards[0].highValue, 'Q') {

        }

        public override Hand compare(Hand other) {
            throw new NotImplementedException();
        }

        public string toString() {
            return String.Format("Quads: {0}", base.toString());
        }

        public void checkRep() {

        }

    }
}
