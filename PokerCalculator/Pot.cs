using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Pot {
        public double pot { get; }
        public double  bb { get; }
        Dictionary<Player, double> contributions;
        Dictionary<Street, List<Action>> actions;

        public Pot(double bb) {
            this.pot = 0;
            this.bb = bb;



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
                if(a.actor == p && typeof(a).IsSubclassOf() ) {
                    return true;
                }
            }
            return false;

        }

        public void registerActivePlayers(List<Player> players) {

        }

        public void handleAction(Action a) {

        }

        ///// UTILITY METHODS //////

        public void toString() {

        }



    }
}
