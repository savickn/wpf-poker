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

        public BestHand(PreflopHand pf, Hand primary, Hand secondary=null, List<Draw> draws=null) {
            this.startingHand = pf;
            this.primary = primary;
            this.secondary = secondary;
            this.draws = draws;
        }

        public bool hasBestHand(PreflopHand pf, Board b) {
            List<Card> availableCards = pf.cards.Concat(b.getCards()).ToList();
            foreach(Card c in this.getCards()) {
                if(!availableCards.Contains(c)) {
                    return false;
                }
            }
            return true;
        }

        public static int compare(BestHand b1, BestHand b2) {
            int case1 = Hand.compare(b1.primary, b2.primary);
            if(case1 != 0) {
                return case1;
            } else {
                int case2 = Hand.compare(b1.secondary, b2.secondary);
                return case2;
            }
        }

        public List<Card> calculateOuts() {
            throw new NotImplementedException();
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

        public string toString() {
            throw new NotImplementedException();
        }

        public void checkRep() {

        }
    }
}

/*public static int compareRankings(int r1, int r2) {
            if(r1 > r2) {
                return 1;
            } else if(r1 < r2) {
                return -1;
            } else {
                return 0;
            }
        }*/
