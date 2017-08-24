using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PokerCalculator {
    class MadeHand {
        private List<Card> cards { get; }
        private int value { get; }
        private string prefix { get; }
        
        public MadeHand(List<Card> cards, int value, string prefix) {
            this.cards = cards;
            this.value = value;
            this.prefix = prefix;
        }

        public string toString() {
            string rep = "";
            foreach(Card c in getCards()) {
                rep += String.Format("{0}, ", c.toString());
            }
            return rep;
        }

        // used to check if a particular hand already exists in a collection
        public static MadeHand operator ==(self, other) {
            return True if self.__identifier == other.getIdentifier() else False
        }

        public int comparePrefixes(MadeHand other) {
            if(getRanking() > other.getRanking()) {
                return -1;
            } else if self.getRanking() < other.getRanking():
                return 1;
            else:
                return 0;
        }

    @abstractmethod
    def compare(self, other):
        ''' To override '''
        pass

########## GETTERS ###########

    public void getCards() {
        return this.cards
    }

    public void getPrimaryValue(self):
        return self.__primaryValue

    def getLength(self):
        return self.__length

    def getIdentifier(self):
        return self.__identifier

    def getRanking()
        return handRankings[self.__prefix]

############ SETTERS #############

# format: W-10-
    def setIdentifier(self, prefix):
        code = 0
        for card in self.__cards:
            code += multipliers[card.getSuit()] + card.getHighValue()
        return prefix + '-' + str(self.__primaryValue) + '-' + str(code)

    ############ UTILITY #############

        def checkRep(self):
        assert self.__identifier[0] == self.__prefix
        assert len(self.__cards) in [0, 2, 3 ,4, 5]


    }
}
