using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Player {
        public int id { get; }
        public string name { get; private set; }
        public string hash { get; private set; }

        public double stack { get; private set; }
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

        public List<Option> populateActions(PotState state) {
            List<Option> opts = new List<Option> { Option.FOLD };
            if (state.currentBet == state.playerContribution) {
                opts.Add(Option.CHECK);
            }
            if (state.currentBet > state.playerContribution) {
                opts.Add(Option.CALL);
            }
            if (state.currentBet >= state.playerContribution) {
                opts.Add(Option.RAISE);
            }
            return opts;
        }

        public Action selectAction(GameState gs, PotState ps) {
            List<Option> opts = this.populateActions(ps);

            /*string prompt = "Select an action: ";
            foreach(Option o in opts) {
                prompt += String.Format("{0} - {1}", opts.IndexOf(o), o); 
            }

            int selection;
            while(true) {
                selection = (int)Console.ReadLine(prompt);
            }*/

            Option selection = opts[Console.Read()];

            Action action;
            if(selection == Option.FOLD) {
                action = new Fold();
            } else if(selection == Option.CHECK) {

            } else if(selection == Option.CALL) {

            } else if(selection == Option.RAISE){

            }
            return action;
        }

        ///// UTILITY METHODS /////



    }
}
