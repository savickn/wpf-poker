using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class HandAnalyzer {
        public PreflopHand hand { get;}
        public Board board { get; }
        private Deck deck;
        public List<Card> availableCards { get; }
        public BestHand bestHand { get; private set; }

        private StraightFlush bestStraightFlush;
        private FourOfAKind bestQuads;
        private FullHouse bestFullHouse;
        private Flush bestFlush;
        private Straight bestStraight;
        private ThreeOfAKind bestTrips;
        private TwoPair bestTwoPair;
        private Pair bestPair;

        private HashSet<FourOfAKind> quads;
        private HashSet<ThreeOfAKind> trips;
        private HashSet<Pair> pairs;
        private HashSet<Flush> flushes;
        private HashSet<Straight> straights;

        private List<Draw> sfGutshotDraws;
        private List<Draw> sfOpenEndedDraws;
        private List<Draw> flushDraws;
        private List<Draw> backdoorFDs;
        private List<Draw> gutshots;
        private List<Draw> openEnders;

        public HandAnalyzer(PreflopHand pf, Board b, bool toPrint=false, bool checkDraws=false) {
            // dependencies
            this.hand = pf;
            this.board = b;
            this.availableCards = pf.cards.Concat(b.getCards()).ToList();
            this.deck = new Deck(new HashSet<Card>(this.availableCards));

            // init class properties
            this.bestHand = null;
            this.quads = new HashSet<FourOfAKind>();
            this.trips = new HashSet<ThreeOfAKind>();
            this.pairs = new HashSet<Pair>();
            this.flushes = new HashSet<Flush>();
            this.straights = new HashSet<Straight>();

            // populate class properties (e.g. poker hands)
            this.analyzePairedHands();
            this.analyzeStraights(checkDraws);
            this.analyzeFlushes(checkDraws);

            // create best possible MadeHand from hand collections
            this.calculateBestHand();
        }

        // BUG --> adds mirror versions of Pairs (e.g. 9h9s and 9s9h)
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
                        if(bestPair is null || pair.value > bestPair.value) {
                            this.bestPair = pair;
                        }
                        this.pairs.Add(pair);
                        break;
                    case 3:
                        var toak = new ThreeOfAKind(tempHand);
                        if (bestTrips is null || toak.value > bestTrips.value) {
                            this.bestTrips = toak;
                        }
                        this.trips.Add(toak);
                        break;
                    case 4:
                        if(bestQuads is null || tempHand[0].highValue > bestQuads.value) {
                            this.bestQuads = new FourOfAKind(tempHand);
                        } 
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
                if(p1 is null) {
                    p1 = p;
                } else if(p2 is null) {
                    p2 = p;
                } else if(p.value > p2.value) {
                    p2 = p;
                } else if(p2.value > p1.value) {
                    Pair temp = p1;
                    p1 = p2;
                    p2 = temp;
                }
            }
            if(!(p1 is null) && !(p2 is null)) {
                this.bestTwoPair = new TwoPair(p1, p2);
            }
        }

        private void checkForFullHouse() {
            ThreeOfAKind toak = null;
            Pair pair = null;

            foreach (Pair p in pairs) {
                if (pair is null || p.value > pair.value) {
                    pair = p;
                }
            }

            foreach (ThreeOfAKind t in trips) {
                if (toak is null) {
                    toak = t;
                } else if (t.value > toak.value) {
                    ThreeOfAKind temp = toak;
                    toak = t;

                    if (pair is null || temp.value > pair.value) {
                        pair = new Pair(temp.cards.GetRange(0, 2));
                    }
                } else if (t.value < toak.value && (pair is null || t.value > pair.value)) {
                    pair = new Pair(t.cards.GetRange(0, 2));
                }
            }

            if(!(toak is null) && !(pair is null)) {
                this.bestFullHouse = new FullHouse(toak, pair);
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
                    if(this.bestStraightFlush is null || s.value > this.bestStraightFlush.value) {
                        this.bestStraightFlush = new StraightFlush(s.cards);
                    }
                }
            }
        }

        //not complete
        private void analyzeStraightDraws(List<Card> sOuts, List<Card> bOuts) {
            if(Enumerable.Range(6, 3).Contains(sOuts.Count)) {
                var oe = new OpenEndedDraw(sOuts);
                if(!this.openEnders.Contains(oe)) {
                    this.openEnders.Add(oe);
                }
            } else if(Enumerable.Range(3, 1).Contains(sOuts.Count)) {
                var gs = new GutshotDraw(sOuts);
                if(!this.gutshots.Contains(gs)) {
                    this.gutshots.Add(gs);
                }
            }
        }

        private void analyzeStraights(bool checkDraws=false) {
            Suit suit = StraightHelpers.getRelevantSuit(this.availableCards);
            HashSet<Card> cards = StraightHelpers.removePairs(this.availableCards, suit);

            HashSet<CardType> types = new HashSet<CardType>();
            foreach(Card c in cards) {
                types.Add(c.type);
            }

            var straightOuts = new List<Card>();
            var backdoorOuts = new List<Card>();

            foreach (Straight s in Data.getStraights().Values) {
                HashSet<CardType> valueTypes = new HashSet<CardType>();
                foreach(Card c in s.cards) {
                    valueTypes.Add(c.type);
                };
                valueTypes.IntersectWith(types);

                if(valueTypes.Count == 5) {
                    var straightCards = Enumerable.Where(cards, c => types.Contains(c.type)).ToList();
                    var straight = new Straight(straightCards);

                    if(this.bestStraight is null || straight.value > this.bestStraight.value) {
                        this.bestStraight = straight;
                        this.straights.Add(straight);
                    } else {
                        if(!this.straights.Contains(straight)) {
                            this.straights.Add(straight);
                        }
                    }
                } else if(valueTypes.Count == 4 && checkDraws) {



                } else if(valueTypes.Count == 3 && checkDraws) {



                }
            }
            if(checkDraws) {
                this.analyzeStraightDraws(straightOuts, backdoorOuts);
            }

            if(this.straights.Count > 0) {
                this.checkForStraightFlushes();
            }
        }

        private void extractBestFlush(List<Card> cards) {
            cards.Sort((x, y) => x.compare(y));
            Flush f = new Flush(cards.GetRange(0, 5));
            if(this.bestFlush is null || f.handComp(this.bestFlush) == 1) {
                this.bestFlush = f;
            }
            this.flushes.Add(f);
        }

        private void analyzeSuit(List<Card> cards, bool checkDraws=false) {
            if(cards.Count >= 5) {
                this.extractBestFlush(cards);
            } else if(cards.Count == 4 && checkDraws) {
                //this.flushDraws.Add();
            } else if(cards.Count == 3 && checkDraws) {
                //this.backdoorFDs.Add();
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

        private HighCard calculateHighCards(List<Card> cards) {
            List<Card> remainingCards = new List<Card>();
            foreach(Card c in this.availableCards) {
                if(!cards.Contains(c)) {
                    remainingCards.Add(c);
                }
            }
            remainingCards.Sort((x, y) => x.compare(y));
            int additionalCards = 5 - cards.Count;

            if(additionalCards > 0) {
                HighCard hc = new HighCard(remainingCards.GetRange(0, additionalCards));
                return hc;
            } else {
                throw new Exception();
            }
        }

        private void calculateBestHand() {
            NullHand nh = new NullHand();

            if(this.bestStraightFlush is null == false) {
                this.bestHand = new BestHand(this.hand, this.bestStraightFlush);
                return;
            }
            if(this.bestQuads is null == false) {
                HighCard hc = this.calculateHighCards(this.bestQuads.cards);
                this.bestHand = new BestHand(this.hand, this.bestQuads, hc);
                return;
            }
            if(this.bestFullHouse is null == false) {
                this.bestHand = new BestHand(this.hand, this.bestFullHouse);
                return;
            }
            if(this.bestFlush is null == false) {
                this.bestHand = new BestHand(this.hand, this.bestFlush);
                return;
            }
            if (this.bestStraight is null == false) {
                this.bestHand = new BestHand(this.hand, this.bestStraight);
                return;
            }
            if (this.bestTrips is null == false) {
                HighCard hc = this.calculateHighCards(this.bestTrips.cards);
                this.bestHand = new BestHand(this.hand, this.bestTrips, hc);
                return;
            }
            if (this.bestTwoPair is null == false) {
                HighCard hc = this.calculateHighCards(this.bestTwoPair.cards);
                this.bestHand = new BestHand(this.hand, this.bestTwoPair, hc);
                return;
            }
            if (this.bestPair is null == false) {
                HighCard hc = this.calculateHighCards(this.bestPair.cards);
                this.bestHand = new BestHand(this.hand, this.bestPair, hc);
                return;
            }
            if(this.bestHand is null) {
                HighCard hc = this.calculateHighCards(new List<Card>());
                this.bestHand = new BestHand(this.hand, hc);
            }
        }
    }
}
