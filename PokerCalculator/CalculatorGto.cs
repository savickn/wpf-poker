using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class CalculatorGto {
        public Range range { get; set; }
        public Board board { get; }
        public List<BestHand> hands { get; private set; }

        public CalculatorGto(Range r, Board b) {
            this.range = r;
            this.board = b;
            this.hands = analyzeBoard();
        }

        ///// CLASS LOGIC /////

        public List<BestHand> analyzeBoard() {

        }

        public double getHandPercentile(PreflopHand h) {

        }

        public List<BestHand> getRankedStartingHands() {

        }

        public List<BestHand> getTopX(double x) {

        }


        ///// STATIC METHODS /////

        public static double getPotOdds(double betSize, double potSize) {
            return betSize / (betSize + potSize);
        }

        public static double getDrawingOdds(int outs, int deckLength, int cardsToCome=1) {
            return outs / deckLength;
        }

        public static double getImpliedOdds(double betSize, double potSize, double drawOdds) {
            return (betSize / drawOdds) - potSize;
        }

        public static double getExpectedValue(double betSize, double potSize, double winPercentage) {
            double winnings = (potSize + betSize) * winPercentage;
            double losses = betSize * (1 - winPercentage);
            return winnings - losses;
        }

        public static double getSemiBluffEquity(double betSize, double potSize, double foldFrequency, double drawOdds) {
            double winnings = potSize * drawOdds + potSize * foldFrequency;
            double losses = betSize * (1 - drawOdds);
            return winnings - losses;
        }

        public static double getBreakEvenFoldFrequency(double betSize, double potSize, double drawOdds) {
            return (betSize * (1 - drawOdds) - potSize * drawOdds) / potSize;
        }

        public static double getMinimumDefenseFrequency() {
            throw new NotImplementedException();
        }

        ///// UTILITY METHODS /////



    }
}
