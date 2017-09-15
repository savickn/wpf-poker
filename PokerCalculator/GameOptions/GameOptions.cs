using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class GameOptions {
        public double ante { get; }
        public double sb { get; }
        public double bb { get; }
        public double maxBuyIn { get; }
        public double minBuyIn { get; }
        public double timer { get; }

        public int cardsPerHand { get; }
        public int numberOfSeats { get; }

        public GameOptions(int cardsPerHand, double sb, double bb, double maxBI, double minBI, double timer=30, double ante=0, int numberOfSeats=9) {
            this.cardsPerHand = cardsPerHand;
            this.numberOfSeats = numberOfSeats;
            this.ante = ante;
            this.sb = sb;
            this.bb = bb;
            this.maxBuyIn = maxBI;
            this.minBuyIn = minBI;
            this.timer = timer;
        }
    }
}
