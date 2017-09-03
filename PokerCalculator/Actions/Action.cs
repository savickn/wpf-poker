using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Action {
        public Player actor { get; }
        //public ActionType type { get; }
        public double amount { get; }
        public Street street { get; }

        public Action(Player actor, double amount, Street street) {
            this.actor = actor;
            //this.type = type;
            this.amount = amount;
            this.street = street;
        }
    }
}
