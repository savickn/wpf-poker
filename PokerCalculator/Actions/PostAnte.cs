using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class PostAnte : Action {
        public PostAnte(Player actor, double amount) : base(actor, amount, "PREFLOP") {

        }
    }
}
