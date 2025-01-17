﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class PotState {
        public double pot { get; }
        //public Street street { get; }
        public double toCall { get; }
        public double minRaise { get; }
        public double currentBet { get; }
        public double maxBet { get; }
        public double playerContribution { get; }

        public PotState(double pot, double currentBet, double contribution, double toCall, double minRaise, double maxBet = Double.PositiveInfinity) {
            this.pot = pot;
            //this.street = street;
            this.toCall = toCall;
            this.minRaise = minRaise;
            this.currentBet = currentBet;
            this.playerContribution = contribution;
            this.maxBet = maxBet;
        }
    }
}
