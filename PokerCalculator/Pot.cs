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
            set {
                if (value != this.potSize) {
                    this.potSize = value;
                    NotifyPropertyChanged("potSize");
                }
            }
        }
        private Dictionary<Player, double> contributions;
        public Dictionary<Player, double> Contributions {
            get { return this.contributions; }
            set {
                if (value != this.contributions) {
                    this.contributions = value;
                    NotifyPropertyChanged("contributions");
                }
            }
        }
        private Dictionary<Street, List<Action>> actions;
        public Dictionary<Street, List<Action>> Actions {
            get { return this.actions; }
            set {
                if (value != this.actions) {
                    this.actions = value;
                    NotifyPropertyChanged("actions");
                }
            }
        }

        public double bb { get; }
        /*public double pot { get; private set; }
        public Dictionary<Player, double> contributions { get; private set; }
        public Dictionary<Street, List<Action>> actions { get; private set; }*/

        public Pot(double bb) {
            this.PotSize = 0;
            this.bb = bb;
            this.contributions = new Dictionary<Player, double>() { };
            this.actions = new Dictionary<Street, List<Action>>() {
                { Street.PREFLOP, new List<Action>() { } },
                { Street.FLOP, new List<Action>() { } },
                { Street.TURN, new List<Action>() { } },
                { Street.RIVER, new List<Action>() { } }
            };
        }

        /// INTERFACE IMPLEMENTATIONS ///

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// CLASS LOGIC /// 

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

        /// get rid of bb from Pot class
        public PotState getState(Player p) {
            var contribution = getPlayerContribution(p);
            var currentBet = getHighestContribution();
            var raise = 2 * (currentBet - contribution);
            var minRaise = raise > 0 ? raise : bb;

            return new PotState(PotSize, currentBet, contribution, minRaise);
        }

        public bool hasActed(Player p, Street s) {
            var activeActions = new List<Type>() { typeof(Call), typeof(Check), typeof(Raise) };
            foreach (Action a in actions[s]) {
                if(a.actor == p && activeActions.Contains(a.GetType())) {
                    return true;
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
            this.PotSize += amount;
        }

        ///// UTILITY METHODS //////

        public string toString() {
            throw new NotImplementedException();
        }
    }
}
