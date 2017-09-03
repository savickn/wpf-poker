﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public class Card {
        //# unique id for each card
        private int id;
        public string initial { get; }
        private string sprite;
        private string identifier;

        public CardType type { get;}
        public Suit suit { get; }
        public int highValue { get; }
        public int lowValue { get; }

        public bool hidden { get; set; }

        public Card(CardType type, Suit suit, int highValue, int lowValue = -1) {
            //this.identifier = '{value}-{suit}'.format(value = value, suit = suit)
            this.type = type;
            this.suit = suit;
            this.initial = Data.getInitial(type);
            this.highValue = highValue;
            this.lowValue = lowValue > -1 ? lowValue : highValue;

            this.hidden = true; // used to determine if card should be drawn face-up or face-down
        }

        public override bool Equals(System.Object obj) {
            // If parameter is null return false.
            if (obj == null) {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Card c = obj as Card;
            if ((System.Object)c == null) {
                return false;
            }

            return (type == c.type) && (suit == c.suit);
        }

        public override int GetHashCode() {
            return highValue * ((int)type ^ (int)suit);
        }

        public bool isEqual(Card other) {
            return this.identifier == other.getIdentifier() ? true : false;
        }

        public static Card operator <(Card argA, Card argB) {
            return argA.highValue < argB.highValue ? argA : argB;
        }

        public static Card operator >(Card argA, Card argB) {
            return argA.highValue > argB.highValue ? argA : argB;
        }

        ////// SETTERS & GETTERS //////

        public string getIdentifier() {
            return identifier;
        }

        public void setState(bool state) {
            //assert state in [True, False]
            this.hidden = state;
        }

        //////// UTILITY METHODS ///////

        public void draw() {
            //this.sprite.draw()
        }

        public string toString() {
            return String.Format("{0} of {1}", type, suit);
        }

        //public void setSprite(string path) {
        //    this.sprite = Avatar.Avatar('/path/to/picture');
        //}

        private void checkRep() {
            //assert highValue in range(2, 15)
            //assert lowValue in [None, 1]
            //assert self.__type in ['Ace', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Jack', 'Queen', 'King']
            //assert self.__suit in ['Spades', 'Hearts', 'Clubs', 'Diamonds']
            //assert isinstance(self.__hidden, bool)
        }
    }
}
