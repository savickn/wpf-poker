using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Seat {
        public int id { get; }
        public Player player { get; private set; }
        public Seat right { get; private set; }
        public Seat left { get; private set; }

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

        ///// UTILITY METHODS /////

        public string toString() {
            throw new NotImplementedException();
        }

        public void draw() {

        }

        public void checkRep() {

        }

    }
}
