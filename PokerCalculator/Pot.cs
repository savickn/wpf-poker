using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Pot {
        public double pot { get; private set; }
        public double  bb { get; }
        public Dictionary<Player, double> contributions { get; private set; }
        public Dictionary<Street, List<Action>> actions { get; private set; }

        public Pot(double bb) {
            this.pot = 0;
            this.bb = bb;
            this.contributions = new Dictionary<Player, double>() { };
            this.actions = new Dictionary<Street, List<Action>>() {
                { Street.PREFLOP, new List<Action>() { } },
                { Street.FLOP, new List<Action>() { } },
                { Street.TURN, new List<Action>() { } },
                { Street.RIVER, new List<Action>() { } }
            };
        }

        public double getHighestContribution() {
            double hc = 0;
            foreach(KeyValuePair<Player, double> p in contributions) {
                if(p.Value > hc) {
                    hc = p.Value;
                }
            }
            return hc;
        }

        public double getPlayerContribution(Player p) {
            return contributions[p];
        }

        // getPublicState

        public bool hasActed(Player p, Street s) {
            foreach(Action a in actions[s]) {
                if(a.actor == p) {
                    switch(a.GetType()) {
                        case typeof(Check):
                            return true;
                        
                    }
                }
            }
            return false;
        }

        public void registerActivePlayers(List<Player> players) {
            foreach(Player p in players) {
                this.contributions[p] = 0;
            }
        }

        public void handleAction(Action a) {
            var amount = a.amount;
            contributions[a.actor] += amount;
            actions[a.street].Add(a);
            pot += amount;
        }

        ///// UTILITY METHODS //////

        public void toString() {

        }



    }
}
