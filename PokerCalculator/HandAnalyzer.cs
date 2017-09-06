using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class HandAnalyzer {
        public PreflopHand hand { get;}
        public Board board { get; }
        public List<Card> availableCards { get; }
        public BestHand bestHand { get; private set; }

        public Deck deck { get; }

        List<FourOfAKind> quads;
        List<FullHouse> fullHouses;
        List<ThreeOfAKind> trips;
        List<TwoPair> twoPairs;
        List<Pair> pairs;

        List<StraightFlush> straightFlushes;
        List<Flush> flushes;
        List<Straight> straights;

        List<Draw> sfGutshotDraws;
        List<Draw> sfOpenEndedDraws;
        List<Draw> flushDraws;
        List<Draw> backdoorFDs;
        List<Draw> gutshots;
        List<Draw> openEnders;


        public HandAnalyzer(PreflopHand pf, Board b, bool toPrint=false, bool checkDraws=false) {
            this.hand = pf;
            this.board = b;
            this.availableCards = pf.cards.Concat(b.getCards()).ToList();
            this.deck = new Deck(new HashSet<Card>(this.availableCards));
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
                var fh = new FullHouse(toak, pair);
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
            foreach(Straight s in this.straights) {
                if(FlushHelpers.isFlush(s.cards)) {
                    this.straightFlushes.Add(new StraightFlush(s.cards));
                }
            }
        }

        private void analyzeStraightDraws() {

        }

        private void analyzeStraights() {

        }

        private void extractBestFlush(List<Card> cards) {
            cards.Sort((x, y) => x.compare(y));
            this.flushes.Add(new Flush(cards.GetRange(0, 5)));
        }

        private List<Flush> analyzeSuit(List<Card> cards, bool checkDraws=false) {
            if(cards.Count >= 5) {
                this.extractBestFlush(cards);
            } else if(cards.Count == 4 && checkDraws) {
                this.flushDraws.Add();
            } else if(cards.Count == 3 && checkDraws) {
                this.backdoorFDs.Add();
            }
        }

        private void analyzeFlushes(bool checkDraws=false) {
            List<Card> spades = new List<Card>();
            List<Card> diamonds = new List<Card>();
            List<Card> clubs = new List<Card>();
            List<Card> hearts = new List<Card>();

            foreach(Card c in this.availableCards) {
                if(c.suit == Suit.CLUBS) {
                    clubs.Add(c);
                } else if(c.suit == Suit.DIAMONDS) {
                    diamonds.Add(c);
                } else if(c.suit == Suit.HEARTS) {
                    hearts.Add(c);
                } else if(c.suit == Suit.SPADES) {
                    spades.Add(c);
                } else {
                    throw new Exception();
                }
            }

            this.analyzeSuit(spades);
            this.analyzeSuit(clubs);
            this.analyzeSuit(diamonds);
            this.analyzeSuit(hearts);
        }

        private HighCard calculateHighCards(List<Card> cards, int length) {
            List<Card> remainingCards = new List<Card>();
            foreach(Card c in this.availableCards) {
                if(!cards.Contains(c)) {
                    remainingCards.Add(c);
                }
            }
            remainingCards.Sort((x, y) => x.compare(y));
            int additionalCards = 5 - length;

            if(additionalCards > 0) {
                HighCard hc = new HighCard(remainingCards.GetRange(0, additionalCards));
                return hc;
            } else {
                throw new Exception();
            }
        }

        private void calculateBestHand() {
            NullHand nh = new NullHand();

            if(this.straightFlushes.Count > 0) {
                StraightFlush sf = this.straightFlushes.Sort((x, y) => x.handComp(y))
            }

        }
    }
}
