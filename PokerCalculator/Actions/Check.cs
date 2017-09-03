using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Check : Action {
        public Check(Player actor, Street street) : base(actor, 0, street) {

        }
    }
}
