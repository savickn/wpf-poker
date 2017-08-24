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
        BestHand bestHand;

        Deck deck;

        List<FourOfAKind> quads;
        List<FullHouse> fullHouses;
        List<ThreeOfAKind> trips;
        List<TwoPair> twoPairs;
        List<Pair> pairs;

        List<MadeHand> straightFlushes;
        List<MadeHand> sfGutshotDraws;
        List<MadeHand> sfOpenEndedDraws;
        List<MadeHand> ;

        public HandAnalyzer() {



        }


    }
}
