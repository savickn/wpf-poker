using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Pot {
        int pot;
        int bb;
        Dictionary<Player, int> contributions;
        Dictionary<string, List<Action>> actions;

        public Pot(int bb) {
            this.pot = 0;

        }

        public void toString() {

        }

        public int getPot() {
            return this.pot;
        }

        public int getHighestContribution() {
            return;
        }

        public int getPlayerContribution() {
            return;
        }

        // getPublicState

        public bool hasActed(Player p, string street) {

        }

        public void registerActivePlayers(List<Player> players) {

        }

        public void handleAction(Action a) {

        }


    }
}
