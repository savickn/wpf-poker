using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Player {
        private string account;
        private string hash;

        private double stack;
        private PreflopHand hand;

        private PlayerStatus status;

        private bool sittingOut;
        private bool autoRebuy;
        private double timeBank;

        //private RangeManager rm;

        public Player() {

        }


        ///// GETTERS & SETTERS /////

        public void setStatus(PlayerStatus ps) {
            status = ps;
        }


        ///// LOGIC /////




        public void addToStack(double amount) {
            stack += amount;
        }

        public BetResponse removeFromStack(double amount) {
            BetResponse br;

            if(stack > amount) {
                stack -= amount;
                br = new BetResponse(amount, true);
            } else if(stack < amount && stack > 0) {
                double temp = stack;
                stack = 0;
                setStatus(PlayerStatus.ALL_IN);
                br = new BetResponse(temp, true);
            } else {
                setStatus(PlayerStatus.SITTING_OUT);
                br = new BetResponse(0, false);
            }

            return br;
        }

        public List<Option> populateActions(state) {
            List<Option> opts = { Option.FOLD }


            return opts;
        }

        public Action selectAction(state) {



        }

        ///// UTILITY METHODS /////



    }
}
