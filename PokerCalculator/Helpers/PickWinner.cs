using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class PickWinner {
        public static double calculateEquitySplit(int winnerCount) {
            return (100 / winnerCount) / 100;
        }

        public static WinState determineWinner(Board b, List<PreflopHand> hands) {
            var analyzers = new Dictionary<string, HandAnalyzer>();
            int iter = 1;
            foreach(PreflopHand h in hands) {
                analyzers.Add(String.Format("hand-{0}", iter), new HandAnalyzer(h, b));
                iter += 1;
            }

            var winningHands = new List<BestHand>();
            foreach(string k in analyzers.Keys) {
                if(winningHands.Count == 0) {
                    winningHands.Add(analyzers[k].bestHand);
                } else {
                    BestHand competitor = analyzers[k].bestHand;
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
