using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator.Actions {
    class Fold : Action {
        public Fold(Player actor, string street) : base(actor, 0, street) {

        }
    }
}
