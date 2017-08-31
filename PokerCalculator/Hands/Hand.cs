using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PokerCalculator {
    abstract class Hand {
        public List<Card> cards { get; }
        public int value { get; }
        public int length { get; }
        public string prefix { get; }
        public string identifier { get; }

        public Hand(List<Card> cards, int value, string prefix) {
            this.cards = cards;
            this.value = value;
            this.prefix = prefix;
        }


        // used to check if a particular hand already exists in a collection
        public static bool operator ==(Hand one, Hand other) {
            return one.identifier == other.identifier ? true : false;
        }

        public static bool operator !=(Hand one, Hand other) {
            return one.identifier != other.identifier ? true : false;
        }

        public int compare(Hand h1, Hand h2) {
            int prefixComparison = comparePrefixes(h1, h2);
            if(prefixComparison == 1 || prefixComparison == -1) {
                return prefixComparison;
            } else {
                

                return h1.handComp(h2);
            }
        }

        ////// Logic Methods //////

        public static int comparePrefixes(Hand h1, Hand h2) {
            if (h1.getRanking() > h2.getRanking()) {
                return 1;
            } else if(h1.getRanking() < h2.getRanking()) {
                return -1;
            } else {
                return 0;
            }
        }

        ////// GETTERS & SETTERS //////

        public int getRanking() {
            return Data.getHandRanking(prefix);
        }

        // format: W-10-
        public void setIdentifier(string prefix) {
            /*code = 0
            for card in self.__cards:
                code += multipliers[card.getSuit()] + card.getHighValue()
            return prefix + '-' + str(self.__primaryValue) + '-' + str(code)
        */}

        /////////// UTILITY ////////////

        public void checkRep() {
            //Assert(this.identifier[0] == this.prefix);
            //assert len(self.__cards) in [0, 2, 3 ,4, 5]
        }

        public string toString() {
            string rep = "";
            foreach (Card c in cards) {
                rep += String.Format("{0}, ", c.toString());
            }
            return rep;
        }

    }
}
