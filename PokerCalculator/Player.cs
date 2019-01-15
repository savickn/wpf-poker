using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PokerCalculator {
    public class Player : INotifyPropertyChanged {

        /* Account Properties */

        public Account account { get; private set; }

        public string Name {
            get { return this.account.name; }
            private set { return; }
        }

        private string image;
        public string Image {
            get { return getImage(); }
            set { image = value; OnPropertyChanged("Image"); }
        }

        /* In-Game Properties */

        private double stack;
        public double Stack {
            get { return this.stack; }
            set { stack = value; OnPropertyChanged("Stack"); }
        }

        private double betAmount;
        public double BetAmount {
            get { return this.betAmount; }
            set { betAmount = value; OnPropertyChanged("BetAmount"); }
        }

        private PreflopHand hand;
        public PreflopHand Hand {
            get { return this.hand; }
            set { hand = value; OnPropertyChanged("Hand"); }
        }

        // can be ACTIVE/SITTING_OUT/etc
        private PlayerStatus status;
        public PlayerStatus Status {
            get { return this.status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        // represents this player's turn to act
        private bool isAwaitingAction;
        public bool IsAwaitingAction {
            get { return isAwaitingAction; }
            set { isAwaitingAction = value; OnPropertyChanged("IsAwaitingAction"); }
        }

        private AwaitingActionEventArgs awaitingActionArgs;

        public bool sittingOut { get; set; }
        public bool autoRebuy { get; set; }
        public double timeBank { get; }

        //private RangeManager rm;

        /* ICommand implementations */

        public ICommand FoldAction { get; set; }
        public ICommand CallAction { get; set; }
        public ICommand RaiseAction { get; set; }
        public ICommand CheckAction { get; set; }
        public ICommand ChangeBetAmount { get; set; }


        /* INotify implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        /* PlayerAction implementation -> responds to PendingPlayerAction Event */

        public event EventHandler<ReceivedActionEventArgs> PlayerAction;

        private void OnPlayerAction(ReceivedActionEventArgs pe) {
            EventHandler<ReceivedActionEventArgs> handler = PlayerAction;
            if (handler != null) {
                handler(this, pe);
            }
        }

        /* AwaitingPlayerAction handler */

        public void AwaitPlayerAction(object sender, AwaitingActionEventArgs e) {
            this.IsAwaitingAction = true;
            this.awaitingActionArgs = e;
            // also need to send gameState/potState/timer/etc
        }

        public void CancelPlayerAction(object sender, CancelActionEventArgs e) {
            this.IsAwaitingAction = false;
            this.awaitingActionArgs = null;
        }

        /* Class Logic */

        public Player(Account acc, double buyin) {
            this.account = acc;
            this.stack = buyin;
            this.status = buyin > 0 ? PlayerStatus.ACTIVE : PlayerStatus.SITTING_OUT;
            this.BetAmount = 0;
            
            this.sittingOut = false;
            this.autoRebuy = false;

            this.RaiseAction = new Command(this.Raise, this.canRaise);
            this.CallAction = new Command(this.Call, this.canCall);
            this.FoldAction = new Command(this.Fold, this.canFold);
            this.CheckAction = new Command(this.Check, this.canCheck);
            this.ChangeBetAmount = new Command(this.changeBetAmount, this.canChangeBetAmount);
        }

        public string getImage() {
            return image != null ? image : "Assets/unknown-user.png";
        }

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

        public void showHand() {
            foreach(Card c in this.hand.cards) {
                c.Hidden = false;
            }
        }

        public void rebuy(double amount) {
            throw new NotImplementedException();
        }

        /* Command implementations */

        private bool canChangeBetAmount(object e) {
            return true;
        }

        private void changeBetAmount(object e) {

        }

        private bool canRaise(object e) {
            //if (awaitingActionArgs == null) return false;
            //return BetAmount >= this.awaitingActionArgs.potState.minRaise;
            return true;
        }

        private void Raise(object e) {
            Raise r = new Raise(this, this.BetAmount, this.awaitingActionArgs.gameState.street);
            OnPlayerAction(new ReceivedActionEventArgs(r));
        }

        private bool canFold(object e) {
            return true;
        }

        private void Fold(object e) {

        }

        private bool canCall(object e) {
            return true;
        }

        private void Call(object e) {

        }

        private bool canCheck(object e) {
            return true;
        }

        private void Check(object e) {
            Action a = new Check(this, Street.FLOP);
            OnPlayerAction(new ReceivedActionEventArgs(a));
        }

        ///// UTILITY METHODS /////

        public string toString() {
            return String.Format("Name: {0}, Stack: {1}", this.account.name, this.stack);
        }

        public void draw() {

        }

        public void checkRep() {

        }
    }
}
