﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class OpenEndedDraw : Draw {

        public OpenEndedDraw(List<Card> cards, List<Card> outs) : base("OpenEnder", cards, outs) {

        }
    }
}
