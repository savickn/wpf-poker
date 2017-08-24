using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Card {
        //# unique id for each card
        private int id;
        private string initial { get; }
        private string sprite;
        private string identifier;

        private string type { get; }
        private Suit suit { get; }
        private int highValue { get; }
        private int lowValue { get; }

        private bool hidden { get; set; }

        public Card(string type, Suit suit, int highValue, int lowValue = -1) {
            //this.identifier = '{value}-{suit}'.format(value = value, suit = suit)
            this.type = type;
            this.suit = suit;
            this.initial = Data.getInitial(type);
            this.highValue = highValue;
            this.lowValue = lowValue > -1 ? lowValue : highValue;

            this.hidden = true; // used to determine if card should be drawn face-up or face-down
        }

        public string toString() {
            return String.Format("{0} of {1}", type, suit);
        }

        // used to check if two Cards are identical (e.g. Js == Js but Jh != Js), not working
        // def __eq__(self, other):
        // return self.getId() == other.getId()

        public bool isEqual(Card other) {
            return this.identifier == other.getIdentifier() ? true : false;
        }

        public static Card operator <(Card argA, Card argB) {
            return argA.highValue < argB.highValue ? argA : argB;
        }

        public static Card operator >(Card argA, Card argB) {
            return argA.highValue > argB.highValue ? argA : argB;
        }

        //def __lt__(self, other):
        //    return self.getHighValue() < other.getHighValue()

        //def __gt__(self, other):
        //    return self.getHighValue() > other.getHighValue()

        private void checkRep() {
            //assert highValue in range(2, 15)
            //assert lowValue in [None, 1]
            //assert self.__type in ['Ace', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Jack', 'Queen', 'King']
            //assert self.__suit in ['Spades', 'Hearts', 'Clubs', 'Diamonds']
            //assert isinstance(self.__hidden, bool)
        }

        ////// SETTERS & GETTERS //////

        public string getIdentifier() {
            return identifier;
        }

        public void setState(bool state) {
            //assert state in [True, False]
            this.hidden = state;
        }

        //////// GRAPHICS ///////

        public void draw() {
            //this.sprite.draw()
        }

        //public void setSprite(string path) {
        //    this.sprite = Avatar.Avatar('/path/to/picture');
        //}
    }
}
