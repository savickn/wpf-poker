using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Seat {
        int id { get; }
        Player player { get; set; }
        Seat right { get; set; }
        Seat left { get; set; }

        public Seat(int id, Seat right, Seat left, Player player) {
            this.id = id;
            this.right = right;
            this.left = left;
            this.player = player;
        }

        public void toString() {

        }

        public void draw() {

        }

        public void checkRep() {

        }

        //// Class Logic ////

        public bool isEmpty() {
            return !this.player ? true : false;
        }

        public bool isActive() {
            return this.player.isActive() ? true : false;
        }

        public Seat getNearestLeftSeatWithActivePlayer() {
            
        }

        public Seat getNearestLeftSeatInHand() {

        }

    }
}
