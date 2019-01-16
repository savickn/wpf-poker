using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class Seat : INotifyPropertyChanged {
        public int id { get; }
        public Player player { get; private set; }
        public Seat right { get; private set; }
        public Seat left { get; private set; }

        public Player Player {
            get { return player; }
            set { player = value; OnPropertyChanged("Player"); }
        }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        public Seat(int id, Seat right=null, Seat left=null, Player player=null) {
            this.id = id;
            this.right = right;
            this.left = left;
            this.player = player;
        }

        //// Class Logic ////

        public bool isEmpty() {
            return player == null ? true : false;
        }

        public bool isActive() {
            return player.isActive() ? true : false;
        }

        ///// GETTERS & SETTERS /////

        public void setLeft(Seat s) {
            this.left = s;
        }

        public void setRight(Seat s) {
            this.right = s;
        }

        public void setPlayer(Player p) {
            this.player = p;
        }

        public string getImage() {
            return "s";
        }

        ///// UTILITY METHODS /////

        public string toString() {
            return String.Format("Seat-{0}... Left = Seat-{1}, Right = Seat-{2}", this.id, this.left.id, this.right.id);
        }
    }
}
