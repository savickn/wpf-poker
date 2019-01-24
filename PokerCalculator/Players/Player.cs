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

        private double currentContribution;
        public double CurrentContribution {
            get { return this.currentContribution; }
            set { this.currentContribution = value; OnPropertyChanged("CurrentContribution"); }
        }

        private double toCall;
        public double ToCall {
            get { return toCall; }
            set { toCall = value; OnPropertyChanged("ToCall"); }
        }

        private double minRaise;
        public double MinRaise {
            get { return minRaise; }
            set { minRaise = value; OnPropertyChanged("MinRaise"); }
        }

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

        private bool isFoldAvailable;
        public bool IsFoldAvailable {
            get { return isFoldAvailable; }
            set { isFoldAvailable = value; OnPropertyChanged("IsFoldAvailable"); }
        }

        private bool isCallAvailable;
        public bool IsCallAvailable {
            get { return isCallAvailable; }
            set { isCallAvailable = value; OnPropertyChanged("IsCallAvailable"); }
        }

        private bool isRaiseAvailable;
        public bool IsRaiseAvailable {
            get { return isRaiseAvailable; }
            set { isRaiseAvailable = value; OnPropertyChanged("IsRaiseAvailable"); }
        }

        private bool isCheckAvailable;
        public bool IsCheckAvailable {
            get { return isCheckAvailable; }
            set { isCheckAvailable = value; OnPropertyChanged("IsCheckAvailable"); }
        }


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

        /* updates Player state to allow Player to make an Action
        * render UI
        * set MinRaise/ToCall/CurrentContribution/etc
        * 
        */
        public void AwaitPlayerAction(object sender, AwaitingActionEventArgs e) {
            if (e.player != this) { return; } // escapes events that are not targeted at this Player

            this.IsAwaitingAction = true;
            this.awaitingActionArgs = e;

            PotState ps = e.potState;
            this.populateActions(ps); // sets available Commands

            // WORKING 
            MinRaise = ps.minRaise;
            ToCall = ps.toCall;
            BetAmount = ps.minRaise;

            // used to immediately update 'canCheck/canRaise'
            CommandManager.InvalidateRequerySuggested();
        }

        public void CancelPlayerAction(object sender, CancelActionEventArgs e) {
            if(e.player != this) { return; } // escapes events that are not targeted at this Player

            IsAwaitingAction = false;
            this.awaitingActionArgs = null;

            IsFoldAvailable = false;
            IsCheckAvailable = false;
            IsCallAvailable = false;
            IsRaiseAvailable = false;

            // update CurrentContribution if necessary, NOT WORKING
            CurrentContribution = e.contribution > 0 ? e.contribution : currentContribution; 

            // used to immediately update 'canCheck/canRaise'
            CommandManager.InvalidateRequerySuggested();
        }

        /* Class Logic */

        public Player(Account acc, double buyin) {
            this.account = acc;
            this.stack = buyin;
            this.status = buyin > 0 ? PlayerStatus.ACTIVE : PlayerStatus.SITTING_OUT;
            this.BetAmount = 0;
            
            this.sittingOut = false;
            this.autoRebuy = false;

            this.RaiseAction = new RelayCommand(this.Raise, this.canRaise);
            this.CallAction = new RelayCommand(this.Call, this.canCall);
            this.FoldAction = new RelayCommand(this.Fold, this.canFold);
            this.CheckAction = new RelayCommand(this.Check, this.canCheck);
            this.ChangeBetAmount = new RelayCommand(this.changeBetAmount, this.canChangeBetAmount);
        }

        // used to determine which actions are available for player/bot
        public void populateActions(PotState state) {
            IsFoldAvailable = state.currentBet != state.playerContribution;
            IsCheckAvailable = state.currentBet == state.playerContribution;
            IsCallAvailable = state.currentBet > state.playerContribution;
            IsRaiseAvailable = state.currentBet >= state.playerContribution;
        }

        public void addToStack(double amount) {
            Stack += amount;
        }

        public BetResponse removeFromStack(double amount) {
            BetResponse br;

            if(stack > amount) {
                Stack -= amount;
                br = new BetResponse(amount, true);
            } else if(stack < amount && stack > 0) {
                double temp = stack;
                Stack = 0;
                Status = PlayerStatus.ALL_IN;
                br = new BetResponse(temp, true);
            } else {
                Status = PlayerStatus.SITTING_OUT;
                br = new BetResponse(0, false);
            }

            return br;
        }

        /* Command implementations */

        private bool canChangeBetAmount(object e) {
            return true;
        }

        private void changeBetAmount(object e) {

        }

        private bool canRaise(object e) {
            if (!isRaiseAvailable) return false;
            if (awaitingActionArgs == null) return false;

            PotState ps = awaitingActionArgs.potState;

            double low = ps.minRaise < stack ? ps.minRaise : stack;
            double high = ps.maxBet < stack ? ps.maxBet : stack;

            return BetAmount >= low && BetAmount <= high;
        }

        private void Raise(object e) {
            Street s = this.awaitingActionArgs.gameState.street;
            double amountOwed = BetAmount - this.awaitingActionArgs.potState.playerContribution;
            BetResponse res = removeFromStack(amountOwed);
            Action a = new Raise(this, res.amount, s);
            OnPlayerAction(new ReceivedActionEventArgs(a));
        }

        private bool canFold(object e) {
            return this.isFoldAvailable;
        }

        private void Fold(object e) {
            Street s = this.awaitingActionArgs.gameState.street;
            Action a = new Fold(this, s);
            Status = PlayerStatus.ACTIVE;
            OnPlayerAction(new ReceivedActionEventArgs(a));
        }

        private bool canCall(object e) {
            return this.isCallAvailable;
        }

        // where 'response.amount' is 'toCall' (allows easy 'removeFromStack')
        private void Call(object e) {
            Street s = this.awaitingActionArgs.gameState.street;
            double betToCall = this.awaitingActionArgs.potState.toCall;
            BetResponse response = removeFromStack(betToCall);
            Action a = new Call(this, response.amount, s);
            OnPlayerAction(new ReceivedActionEventArgs(a));
        }

        private bool canCheck(object e) {
            return this.isCheckAvailable;
        }

        private void Check(object e) {
            Street s = this.awaitingActionArgs.gameState.street;
            Action a = new Check(this, s);
            OnPlayerAction(new ReceivedActionEventArgs(a));
        }

        ///// UTILITY METHODS /////

        public string toString() {
            return String.Format("Name: {0}, Stack: {1}", this.account.name, this.stack);
        }

        /* SETTERS & GETTERS */

        public string getImage() {
            return image != null ? image : "Assets/unknown-user.png";
        }

        public bool isActive() {
            return status == PlayerStatus.ACTIVE;
        }

        public bool isInHand() {
            return status == PlayerStatus.IN_HAND;
        }

        public bool shouldAnalyze() {
            var passingStates = new List<PlayerStatus>() { PlayerStatus.IN_HAND, PlayerStatus.ALL_IN };
            return passingStates.Contains(status);
        }

        public void showHand() {
            foreach (Card c in this.hand.cards) {
                c.Hidden = false;
            }
        }

        public void rebuy(double amount) {
            throw new NotImplementedException();
        }

    }
}




/* OLD 
 * 
        
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
    }

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

*/
  