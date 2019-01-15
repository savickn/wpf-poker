using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

/*
 * 
 * 
 */

namespace PokerCalculator {
    public class Card : INotifyPropertyChanged {
   
        /* Ids */ 

        private int id; // unique id for each card
        public string identifier { get; private set; }
        public string initial { get; }

        /* Logic */

        public CardType type { get; }
        public Suit suit { get; }
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
            set { hidden = value; OnPropertyChanged("Hidden"); OnPropertyChanged("Image"); }
        }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        /* Class Logic */

        public Card(string imagePath, CardType type, Suit suit, int highValue, int lowValue = -1) {
            //this.identifier = '{value}-{suit}'.format(value = value, suit = suit)
            this.initial = Data.getInitial(type);

            this.type = type;
            this.suit = suit;
            this.highValue = highValue;
            this.lowValue = lowValue > -1 ? lowValue : highValue;

            Image = imagePath;
            this.cover = "Gray_back.jpg"; // needs to be refactored
            this.hidden = true; // used to determine if card should be drawn face-up or face-down
        }


        /* purpose ??? */
        public int compare(Card other) {
            if(this.highValue > other.highValue) {
                return 1;
            } else if(this.highValue < other.highValue) {
                return -1;
            } else {
                return 0;
            }
        }

        /* purpose ??? */
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

        public void setState(bool state) {
            //assert state in [True, False]
            this.hidden = state;
        }

        //////// UTILITY METHODS ///////

        public Card clone() {
            return (Card)this.MemberwiseClone();
        }

        public string toString() {
            return String.Format("{0} of {1}", type, suit);
        }

        private void checkRep() {
            //assert highValue in range(2, 15)
            //assert lowValue in [None, 1]
            //assert self.__type in ['Ace', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 'Jack', 'Queen', 'King']
            //assert self.__suit in ['Spades', 'Hearts', 'Clubs', 'Diamonds']
            //assert isinstance(self.__hidden, bool)
        }
    }
}
