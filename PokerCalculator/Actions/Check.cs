﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Check : Action {
        public Check(Player actor, string street) : base(actor, 0, street) {

        }
    }
}
