using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Card {
        //# unique id for each card
        private int id;
        private float sprite;
        private string identifier;

        private string type;
        private enum suit;
        private int highValue;
        private int lowValue;

        public void Card(string type, enum suit, int value, options = defaultOptions) {
            //this.identifier = '{value}-{suit}'.format(value = value, suit = suit)
            this.type = type;
            this.suit = suit;
            this.highValue = value
            this.lowValue = options['low_value'] if options['low_value'] is not None else value

            self.__hidden = True #used to determine if card should be drawn face-up or face-down

            self.checkRep()
        }

        public string toString() {
            return '{type} of {suit}'.format(type = this.type, suit = this.suit);
        }

# used to check if two Cards are identical (e.g. Js == Js but Jh != Js), not working
# def __eq__(self, other):
# return self.getId() == other.getId()

        def isEqual(self, other):
        return True if self.__identifier == other.getIdentifier() else False

    def __lt__(self, other):
        return self.getHighValue() < other.getHighValue()

    def __gt__(self, other):
        return self.getHighValue() > other.getHighValue()

    def checkRep(self):
        assert self.__high_value in range(2, 15)
        #assert self.__low_value in [None, 1]
        assert self.__type in ['Ace', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Jack', 'Queen', 'King']
        assert self.__suit in ['Spades', 'Hearts', 'Clubs', 'Diamonds']
        assert isinstance(self.__hidden, bool)

    ########## SETTERS & GETTERS ############

        public string getIdentifier() {
            return this.identifier;
        }

        public string getInitial() {
            return initials[this.type];
        }

        public int getHighValue() {
            return this.highValue;
        }

        public int getLowValue() {
            return this.lowValue;
        }

        public string getType() {
            return this.type;
        }

        public enum getSuit() {
            return this.suit;
        }

        public bool getState() {
            return this.hidden;
        }

        public void setState(bool state) {
            //assert state in [True, False]
            this.hidden = state;
        }

        //////// GRAPHICS ///////

        def draw(self):
            self.__sprite.draw()

        def setSprite(self):
            self.__sprite = Avatar.Avatar('/path/to/picture')


    }
}
