using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class Player {
        public int id { get; }
        public string name { get; private set; }
        public string hash { get; private set; }

        public double stack { get; private set; }
        public PreflopHand hand { get; private set; }
        public PlayerStatus status { get; private set; }

        public bool sittingOut { get; set; }
        public bool autoRebuy { get; set; }
        public double timeBank { get; }

        //private RangeManager rm;

        public Player(string name, double buyin) {
            this.name = name;
            this.stack = buyin;
            this.status = buyin > 0 ? PlayerStatus.ACTIVE : PlayerStatus.SITTING_OUT;

            this.sittingOut = false;
            this.autoRebuy = false;
        }

        ///// CLASS LOGIC /////

        public bool isActive() {
            return status == PlayerStatus.ACTIVE ? true : false;
        }

        public bool isInHand() {
            return status == PlayerStatus.IN_HAND ? true : false;
        }

        public bool shouldAnalyze() {
            var passingStates = new List<PlayerStatus>() { PlayerStatus.IN_HAND, PlayerStatus.ALL_IN };
            return passingStates.Contains(status) ? true : false;
        }

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

            //render betView + timerView for "Player p" and populate betView with "opts"



            /*string prompt = "Select an action: ";
            foreach(Option o in opts) {
                prompt += String.Format("{0} - {1}", opts.IndexOf(o), o); 
            }

            int selection;
            while(true) {
                selection = (int)Console.ReadLine(prompt);
            }*/

            //int x = Console.ReadLine();
            Option selection = opts[Console.Read()];

            Action action;
            if(selection == Option.FOLD) {
                action = new Fold(this, gs.street);
                this.status = PlayerStatus.ACTIVE;
            } else if(selection == Option.CHECK) {
                action = new Check(this, gs.street);
            } else if(selection == Option.CALL) {
                double betToCall = ps.currentBet - ps.playerContribution;
                BetResponse response = removeFromStack(betToCall);
                action = new Call(this, response.amount, gs.street);
            } else {  // for raises
                double low = ps.minRaise < stack ? ps.minRaise : stack;
                double high = ps.maxBet < stack ? ps.maxBet : stack;

                // add code to ensure amount is always between 'low' and 'high'
                double amount = Convert.ToDouble(Console.ReadLine());
                BetResponse res = removeFromStack(amount);
                action = new Raise(this, res.amount, gs.street);
            }
            return action;
        }

        ///// GETTERS & SETTERS /////

        public void setStatus(PlayerStatus ps) {
            this.status = ps;
        }

        public void setHand(PreflopHand hand) {
            this.hand = hand;
        }

        public void rebuy(double amount) {
            throw new NotImplementedException();
        }

        ///// UTILITY METHODS /////

        public string toString() {
            return String.Format("Name: {0}, Stack: {1}", this.name, this.stack);
        }

        public void draw() {

        }

        public void checkRep() {

        }
    }
}
