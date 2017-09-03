using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator.Actions {
    class PostBB : Action {
        public PostBB(Player actor, double amount) : base(actor, amount, Street.PREFLOP) {

        }
    }
}
