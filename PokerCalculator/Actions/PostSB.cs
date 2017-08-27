using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator.Actions {
    class PostSB : Action {
        public PostSB(Player actor, double amount) : base(actor, amount, "PREFLOP") {

        }
    }
}
