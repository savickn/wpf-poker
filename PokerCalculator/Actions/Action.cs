using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Action {
        public Player actor { get; }
        public double amount { get; }
        public string street { get; }

        public Action(Player actor, double amount, string street) {
            this.actor = actor;
            this.amount = amount;
            this.street = street;
        }
    }
}
