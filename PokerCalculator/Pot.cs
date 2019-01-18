using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PokerCalculator {
    public class Pot : INotifyPropertyChanged {
        private double potSize;
        public double PotSize {
            get { return this.potSize; }
            set { this.potSize = value; OnPropertyChanged("PotSize"); }
        }
        /*private Dictionary<Player, double> contributions;
        public Dictionary<Player, double> Contributions {
            get { return this.contributions; }
            set {
                if (value != this.contributions) {
                    this.contributions = value;
                    OnPropertyChanged("Contributions");
                }
            }
        }*/
        private Dictionary<Street, List<Action>> actions;
        public Dictionary<Street, List<Action>> Actions {
            get { return this.actions; }
            set {
                if (value != this.actions) {
                    this.actions = value;
                    OnPropertyChanged("Actions");
                }
            }
        }

        private Dictionary<Street, Dictionary<Player, double>> contributionsByStreet;
        private double currentRaise;

        public double bb { get; }
        /*public double pot { get; private set; }
        public Dictionary<Player, double> contributions { get; private set; }
        public Dictionary<Street, List<Action>> actions { get; private set; }*/

        /* INotify implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /* Class Logic */

        public Pot(double bb) {
            this.PotSize = 0;
            this.bb = bb;
            this.currentRaise = 0;
            //this.contributions = new Dictionary<Player, double>() { };
            this.actions = new Dictionary<Street, List<Action>>() {
                { Street.PREFLOP, new List<Action>() { } },
                { Street.FLOP, new List<Action>() { } },
                { Street.TURN, new List<Action>() { } },
                { Street.RIVER, new List<Action>() { } }
            };
            this.contributionsByStreet = new Dictionary<Street, Dictionary<Player, double>>() {
                { Street.PREFLOP, new Dictionary<Player, double>() { } },
                { Street.FLOP, new Dictionary<Player, double>() { } },
                { Street.TURN, new Dictionary<Player, double>() { } },
                { Street.RIVER, new Dictionary<Player, double>() { } },
            };
        }

        // initializes Dictionary mapping each Player to their pot contribution on every Street, WORKING
        public void registerActivePlayersByStreet(List<Player> players, Street s) {
            foreach (Player p in players) {
                this.contributionsByStreet[s][p] = 0;
            }
        }

        // used to calculate potSize based on all current streets
        public double calcPotSize() {
            double value = 0;
            foreach (KeyValuePair<Street, Dictionary<Player, double>> streets in contributionsByStreet) {
                foreach (KeyValuePair<Player, double> p in streets.Value) {
                    value += p.Value;
                }
            }
            return value;
        }

        // used as currentBet on Street (e.g. currentBet - playerContribution === amountToCall)
        public double getHighestContributionByStreet(Street s) {
            double hc = 0;
            foreach (KeyValuePair<Player, double> p in contributionsByStreet[s]) {
                if (p.Value > hc) {
                    hc = p.Value;
                }
            }
            return hc;
        }

        // returns pot contribution of player on specific Street
        public double getPlayerContributionByStreet(Player p, Street s) {
            return contributionsByStreet[s][p];
        }

        /// buggy, need better way to track/calc minRaise (e.g. if Raise set minRaise)
        /// PostSB --> WORKING
        /// PostBB --> WORKING
        /// Call --> NOT WORKING
        /// Raise --> ???
        public void handleAction(Action a) {
            var currentBet = this.getHighestContributionByStreet(a.street);

            actions[a.street].Add(a); // add Acton to List<Action>

            // handle Call, not being called cuz 
            if (a is Call) {
                contributionsByStreet[a.street][a.actor] += a.amount;
            }

            // handle Raise, PostSB, PostBB
            if (a.amount > currentBet) {
                contributionsByStreet[a.street][a.actor] = a.amount;
                if(a is Raise) {
                    this.currentRaise = a.amount - currentBet;
                }
            }

            this.PotSize = this.calcPotSize();
        }

        /// should work
        public PotState getState(Player p, Street s) {
            var currentBet = getHighestContributionByStreet(s);
            var contribution = getPlayerContributionByStreet(p, s);
            var toCall = currentBet - contribution;
            var minRaise = this.currentRaise > 0 ? currentBet + this.currentRaise : currentBet + bb;

            return new PotState(PotSize, currentBet, contribution, toCall, minRaise);
        }

        // checks if Player has acted on a given Street
        public bool hasActed(Player p, Street s) {
            var activeActions = new List<Type>() { typeof(Call), typeof(Check), typeof(Raise) };
            foreach (Action a in actions[s]) {
                if (a.actor == p && activeActions.Contains(a.GetType())) {
                    return true;
                }
            }
            return false;
        }

        ///// UTILITY METHODS //////

        public string toString() {
            throw new NotImplementedException();
        }
    }
}


/* old */

// used as currentBet (e.g. currentBet - playerContribution === amountToCall)
/*public double getHighestContribution() {
    double hc = 0;
    foreach (KeyValuePair<Player, double> p in contributions) {
        if (p.Value > hc) {
            hc = p.Value;
        }
    }
    return hc;
}

// used to retrieve pot contribution of specific player
public double getPlayerContribution(Player p) {
    return contributions[p];
}

// initializes Dictionary mapping each Player to their pot contribution, WORKING
public void registerActivePlayers(List<Player> players) {
    foreach (Player p in players) {
        this.contributions[p] = 0;
    }
}
*/