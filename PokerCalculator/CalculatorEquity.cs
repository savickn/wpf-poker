using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class CalculatorEquity {
        public List<Equity> equities;
        public Board board;
        public int iterations;
        public List<Card> deadCards;

        public CalculatorEquity(List<PreflopHand> hands, Board board=null, int iterations=1000) {
            this.board = board;
            this.iterations = iterations;

            this.deadCards = board.getCards().Concat(hands[0].cards).Concat(hands[1].cards).ToList();
            this.equities = new List<Equity>() {
                new Equity(hands[0]),
                new Equity(hands[1])
            };
        }

        public void run() {
            List<PreflopHand> hands = this.equities.Select(eq => eq.hand).ToList();

            foreach(int n in Enumerable.Range(0, this.iterations)) {
                Deck d = new Deck(new HashSet<Card>(this.deadCards));
                Board b = Board.generateBoard(d, this.board);

                WinState ws = PickWinner.determineWinner(b, hands);
                foreach(Equity eq in this.equities) {
                    bool matched = false;
                    foreach(BestHand bh in ws.winningHands) {
                        if(bh.hasBestHand(eq.hand, b)) {
                            matched = true;
                        }
                        if(matched) {
                            eq.updateEquity(ws.equity);
                        } else {
                            eq.updateEquity(0);
                        }
                    }
                }
            }
        }

        /////// UTILITY METHODS ///////

        public void checkRep() {

        }
    }
}
