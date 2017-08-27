using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Seat {
        public int id { get; }
        public Player player { get; set; }
        public Seat right { get; set; }
        public Seat left { get; set; }

        public Seat(int id, Seat right, Seat left, Player player) {
            this.id = id;
            this.right = right;
            this.left = left;
            this.player = player;
        }

        //// Class Logic ////

        public bool isEmpty() {
            return !player ? true : false;
        }

        public bool isActive() {
            return player.isActive() ? true : false;
        }

        public Seat getNearestLeftSeatWithActivePlayer() {
            Seat temp = left;
            
            foreach(int n in Enumerable.Range(1, 10)) {


            }
        }

        public Seat getNearestLeftSeatInHand() {

        }

        ///// UTILITY METHODS /////

        public void toString() {

        }

        public void draw() {

        }

        public void checkRep() {

        }

    }
}
