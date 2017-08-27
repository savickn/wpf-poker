using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class BestHand {
        public PreflopHand startingHand { get; }
        public Hand primary { get; }
        public Hand secondary { get; }
        public List<Draw> draws { get; }

        public BestHand() {

        }

        public bool hasBestHand(PreflopHand pf, Board b) {
            List<Card> availableCards = pf.cards.Concat(b.getCards()).ToList();

        }

        public static int compareRankings(int r1, int r2) {
            if(r1 > r2) {
                return 1;
            } else if(r1 < r2) {
                return -1;
            } else {
                return 0;
            }
        }






        ///////// GETTERS & SETTERS /////////

        public List<Card> getCards() {
            return primary.cards.Concat(secondary.cards).ToList();
        }

        public void addDraw(Draw d) {
            if(Data.getHandRanking(d.type) > Data.getHandRanking(primary.prefix)) {
                draws.Add(d);
            }
        }

        //////// UTILITY ////////

        public void checkRep() {

        }


    }
}
