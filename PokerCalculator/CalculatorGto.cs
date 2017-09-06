using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class CalculatorGto<T> where T : PreflopHand {
        public Range<T> range { get; set; }
        public Board board { get; }
        public List<BestHand> hands { get; private set; }

        public CalculatorGto(Range<T> r, Board b) {
            this.range = r;
            this.board = b;
            this.hands = analyzeBoard();
        }

        ///// CLASS LOGIC /////

        public List<BestHand> analyzeBoard() {
            var madeHands = new List<BestHand>();
            foreach(T h in this.range.hands) {
                var ha = new HandAnalyzer(h, this.board);
                madeHands.Add(ha.bestHand);
            }
            madeHands.Sort((x,y) => BestHand.compare(x, y));
            return madeHands;
        }

        public double getHandPercentile(T h) {
            var rankedHands = this.getRankedStartingHands();
            int idx = rankedHands.IndexOf(h);
            return 1 - (idx / (this.hands.Count + 1));
        }

        public List<PreflopHand> getRankedStartingHands() {
            var startingHands = this.hands.Select(h => h.startingHand).ToList();
            return startingHands;
        }

        public List<BestHand> getTopX(double x) {
            int cutoff = (int)Math.Ceiling(this.hands.Count / (100 / x));
            var bhs = this.hands.GetRange(cutoff, hands.Count - cutoff);
            return bhs;
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
