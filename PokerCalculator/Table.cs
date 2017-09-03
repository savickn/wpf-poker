using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Table {
        public List<Seat> seats { get; private set; }

        public List<Player> seated { get; private set; }
        public List<Player> observers { get; private set; }
        public List<Player> waitlist { get; private set; }

        public Table() {

        }

        //// CLASS LOGIC ////

        public Seat getNearestLeftSeatWithStatus(Seat s, List<PlayerStatus> query) {
            Seat temp = s.left;

            foreach (int i in Enumerable.Range(0, seats.Count)) {
                Player p = temp.player;
                if (p != null && (query.Contains(p.status)) && p != temp.player) {
                    return temp;
                } else {
                    temp = temp.left;
                }
            }
            // create Exception if a valid Seat cannot be found
            throw new NoValidSeatException();
        }
        
        public void initializeSeats(int seatCount) {
            var seats = new List<Seat>();
            Seat rightSeat = null;

            foreach(int i in Enumerable.Range(0, seatCount)) {
                if(rightSeat != null) {
                    Seat seat = new Seat(i + 1, rightSeat);
                    seats.Add(seat);
                    rightSeat.setLeft(seat);
                    rightSeat = seat;
                } else {
                    Seat seat = new Seat(i + 1);
                    seats.Add(seat);
                    rightSeat = seat;
                }
            }

            Seat firstSeat = seats[0];
            Seat lastSeat = seats[seats.Count - 1];
            firstSeat.setRight(lastSeat);
            lastSeat.setLeft(firstSeat);
        }

        public void addSeat() {
            // add assertion to ensure seatCount < 10
            Seat firstSeat = seats[0];
            Seat lastSeat = seats[seats.Count - 1];

            Seat newSeat = new Seat(seats.Count + 1, lastSeat, firstSeat);
            seats.Add(newSeat);
        }

        public void removeSeat() {
            // add assertion to ensure seatCount > 2
            foreach(Seat s in seats) {
                throw new NotImplementedException();
            }
        }

        public List<Seat> getFilledSeats() {
            throw new NotImplementedException();
        }

        public List<Seat> getActiveSeats() {
            throw new NotImplementedException();
        }

        public List<Player> getActivePlayers() {
            throw new NotImplementedException();
        }

        public List<Player> getInHandPlayers() {
            throw new NotImplementedException();
        }

        public List<Player> getPlayersToAnalyze() {
            throw new NotImplementedException();
        }

        /// UTILITY METHODS ///

        public string toString() {
            throw new NotImplementedException();
        }

        public void checkRep() {

        }

        public void draw() {

        }
    }
}
