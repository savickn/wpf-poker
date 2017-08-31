using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class HandAnalyzer {
        PreflopHand hand;
        Board board;
        List<Card> availableCards;
        public BestHand bestHand { get; private set; }

        Deck deck;

        List<FourOfAKind> quads;
        List<FullHouse> fullHouses;
        List<ThreeOfAKind> trips;
        List<TwoPair> twoPairs;
        List<Pair> pairs;

        List<Hand> straightFlushes;
        List<Hand> sfGutshotDraws;
        List<Hand> sfOpenEndedDraws;

        public HandAnalyzer() {



        }

        private void analyzePTQ() {
            foreach(Card c1 in availableCards) {
                var tempHand = new List<Card> { c1 };
                
                foreach(Card c2 in availableCards) {
                    if(c1 == c2) {
                        continue;
                    }
                    if(c1.highValue == c2.highValue) {
                        tempHand.Add(c2);
                    }
                }
                
                switch(tempHand.Count) {
                    case 2:
                        var pair = new Pair(tempHand);
                        //code to add pair to this.pairs
                        break;
                    case 3:
                        var trips = new ThreeOfAKind(tempHand);
                        //code to add pair to this.pairs
                        break;
                    case 4:
                        var quads = new FourOfAKind(tempHand);
                        //code to add pair to this.pairs
                        break;
                    default:
                        continue;
                }
            }
        }

        private void checkForTwoPair() {
            Pair p1 = null;
            Pair p2 = null;

            foreach(Pair p in pairs) {
                if(p1 == null) {
                    p1 = p;
                } else if(p2 == null) {
                    p2 = p;
                } else if(p.value > p2.value) {
                    p2 = p;
                } else if(p2.value > p1.value) {
                    Pair temp = p1;
                    p1 = p2;
                    p2 = temp;
                }
            }
            if(p1 != null && p2 != null) {
                var tp = new TwoPair(p1, p2);
                //check for duplicates
                twoPairs.Add(tp);
            }
        }

        private void checkForFullHouse() {
            ThreeOfAKind toak = null;
            Pair pair = null;

            foreach (Pair p in pairs) {
                if (pair == null || p.value > pair.value) {
                    pair = p;
                }
            }

            foreach (ThreeOfAKind t in trips) {
                if (toak == null) {
                    toak = t;
                } else if (t.value > toak.value) {
                    ThreeOfAKind temp = toak;
                    toak = t;

                    if (pair == null || temp.value > pair.value) {
                        pair = new Pair(temp.cards.GetRange(0, 2));
                    }
                } else if (t.value < toak.value && (pair == null || t.value > pair.value)) {
                    pair = new Pair(t.cards.GetRange(0, 2));
                }
            }

            if(toak != null && pair != null) {
                var fh = new FullHouse();
                //check for duplicates
                fullHouses.Add(fh);
            }
        }

        private void analyzePairedHands() {
            analyzePTQ();

            if(trips.Count == 2 || (trips.Count >= 1 && pairs.Count >= 1)) {
                checkForFullHouse();
            }

            if(pairs.Count >= 2) {
                checkForTwoPair();
            }
        }

        private void checkForStraightFlushes() {

        }

        private void analyzeStraightDraws() {

        }

        private void analyzeStraight() {

        }

        private void extractBestFlush(List<Card> cards) {

        }

        private List<Flush> analyzeSuit(List<Card> cards, object data, bool checkDraws=false) {

        }

        private void analyzeFlushes(bool checkDraws=false) {

        }
    }
}
