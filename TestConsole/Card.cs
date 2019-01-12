using System;
using System.ComponentModel;
using System.Diagnostics;

namespace TestConsole {
    public class Card {
        //# unique id for each card
        private int id;
        public string identifier { get; }
        public string initial { get; } // refers to the first letter of its Type, e.g. Ace === 'A' (should change to 'abbr' for abbreviation)

        public CardType type { get; }
        public Suit suit { get; set; }
        public int highValue { get; }
        public int lowValue { get; }

        /* Images */

        private string image;
        private string cover;
        private bool hidden;

        public string Image {
            get { return getImage(); }
            set { image = value; /*OnPropertyChanged("Image");*/ }
        }

        public bool Hidden {
            get { return hidden; }
            set { hidden = value; /*OnPropertyChanged("Hidden");*/ }
        }

        /* Class Logic */

        public Card(string imagePath, CardType type, Suit suit, int highValue, int lowValue = -1) {
            //this.identifier = '{value}-{suit}'.format(value = value, suit = suit)

            this.type = type;
            this.suit = suit;
            this.highValue = highValue;
            this.lowValue = lowValue > -1 ? lowValue : highValue;

            Image = imagePath;
            this.cover = "Gray_back.jpg";
            this.hidden = true; // used to determine if card should be drawn face-up or face-down
        }

        public int compare(Card other) {
            if (this.highValue > other.highValue) {
                return 1;
            } else if (this.highValue < other.highValue) {
                return -1;
            } else {
                return 0;
            }
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
            return this.identifier == other.identifier ? true : false;
        }

        public static Card operator <(Card argA, Card argB) {
            return argA.highValue < argB.highValue ? argA : argB;
        }

        public static Card operator >(Card argA, Card argB) {
            return argA.highValue > argB.highValue ? argA : argB;
        }

        ////// SETTERS & GETTERS //////

        public string getImage() {
            string pCover = String.Format("Assets/CardCovers/{0}", this.cover);
            string pImage = String.Format("Assets/Cards/{0}", this.image);
            return this.hidden ? pCover : pImage;
        }


        //////// UTILITY METHODS ///////

        public Card clone() {
            return (Card)this.MemberwiseClone();
        }

        public string toString() {
            return String.Format("{0} of {1}, {2}", type, suit, hidden);
        }
    }
}
