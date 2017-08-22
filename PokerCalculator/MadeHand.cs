using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PokerCalculator {
    class MadeHand {
        private List<Card> cards;
        private int value;
        private string prefix;
        
        public MadeHand(List<Card> cards, int value, string prefix) {
            this.cards = cards;
            this.value = value;
            this.prefix = prefix;
        }

        public string toString() {
            string rep;
            foreach() {

            }
        }

        def __str__(self):
        rep = None
        for c in self.getCards():
            rep = c.toString() if rep is None else rep + ', {card}'.format(card= c.toString())
        return rep

# used to check if a particular hand already exists in a collection
    def __eq__(self, other):
        return True if self.__identifier == other.getIdentifier() else False

    def comparePrefixes(self, other):
        if self.getRanking() > other.getRanking():
            return -1
        elif self.getRanking() < other.getRanking():
            return 1
        else:
            return 0

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

    def getPrefix(self):
        return self.__prefix

    def getIdentifier(self):
        return self.__identifier

    def getRanking(self):
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
