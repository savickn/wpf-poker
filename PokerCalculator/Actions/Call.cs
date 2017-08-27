using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Call : Action {
        public Call(Player actor, double amount, string street) : base(actor, amount, street) {

        }
    }
}
