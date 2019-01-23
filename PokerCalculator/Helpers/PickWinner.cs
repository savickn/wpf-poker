using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class PickWinner {
        // used to ___???
        public static double calculateEquitySplit(int winnerCount) {
            return (100 / winnerCount) / 100;
        }

        // used to ___???
        public static WinState determineWinner(Board b, List<PreflopHand> hands) {
            var analyzers = new Dictionary<string, HandAnalyzer>();
            foreach(PreflopHand h in hands) {
                analyzers.Add(String.Format("hand-{0}", hands.IndexOf(h)), new HandAnalyzer(h, b));
            }

            var winningHands = new List<BestHand>(); // tracks all hands that are due a share of the Pot
            foreach(KeyValuePair<string, HandAnalyzer> a in analyzers) {
                BestHand competitor = analyzers[a.Key].bestHand;
                if(winningHands.Count == 0) {
                    winningHands.Add(competitor);
                } else {
                    int winner = BestHand.compare(competitor, winningHands[0]);
                    if(winner == 0) {
                        winningHands.Add(competitor);
                    } else if(winner == 1) {
                        winningHands = new List<BestHand>() { competitor };
                    }
                }
            }

            double equity = PickWinner.calculateEquitySplit(winningHands.Count);
            return new WinState(equity, winningHands);
        }
    }
}
