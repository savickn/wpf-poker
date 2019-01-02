using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class DataInstance {
        public Card ACE_OF_CLUBS;
        public Card KING_OF_CLUBS;
        public Card QUEEN_OF_CLUBS;
        public Card JACK_OF_CLUBS;
        public Card TEN_OF_CLUBS;
        public Card NINE_OF_CLUBS;
        public Card EIGHT_OF_CLUBS;
        public Card SEVEN_OF_CLUBS;
        public Card SIX_OF_CLUBS;
        public Card FIVE_OF_CLUBS;
        public Card FOUR_OF_CLUBS;
        public Card THREE_OF_CLUBS;
        public Card TWO_OF_CLUBS;
        public Card ACE_OF_HEARTS;
        public Card KING_OF_HEARTS;
        public Card QUEEN_OF_HEARTS;
        public Card JACK_OF_HEARTS;
        public Card TEN_OF_HEARTS;
        public Card NINE_OF_HEARTS;
        public Card EIGHT_OF_HEARTS;
        public Card SEVEN_OF_HEARTS;
        public Card SIX_OF_HEARTS;
        public Card FIVE_OF_HEARTS;
        public Card FOUR_OF_HEARTS;
        public Card THREE_OF_HEARTS;
        public Card TWO_OF_HEARTS;
        public Card ACE_OF_DIAMONDS;
        public Card KING_OF_DIAMONDS;
        public Card QUEEN_OF_DIAMONDS;
        public Card JACK_OF_DIAMONDS;
        public Card TEN_OF_DIAMONDS;
        public Card NINE_OF_DIAMONDS;
        public Card EIGHT_OF_DIAMONDS;
        public Card SEVEN_OF_DIAMONDS;
        public Card SIX_OF_DIAMONDS;
        public Card FIVE_OF_DIAMONDS;
        public Card FOUR_OF_DIAMONDS;
        public Card THREE_OF_DIAMONDS;
        public Card TWO_OF_DIAMONDS;
        public Card ACE_OF_SPADES;
        public Card KING_OF_SPADES;
        public Card QUEEN_OF_SPADES;
        public Card JACK_OF_SPADES;
        public Card TEN_OF_SPADES;
        public Card NINE_OF_SPADES;
        public Card EIGHT_OF_SPADES;
        public Card SEVEN_OF_SPADES;
        public Card SIX_OF_SPADES;
        public Card FIVE_OF_SPADES;
        public Card FOUR_OF_SPADES;
        public Card THREE_OF_SPADES;
        public Card TWO_OF_SPADES;

        public HashSet<Card> deck;

        public DataInstance() {
            /*this.ACE_OF_CLUBS = new Card(CardType.ACE, Suit.CLUBS, 14, 1);
            this.KING_OF_CLUBS = new Card(CardType.KING, Suit.CLUBS, 13);
            this.QUEEN_OF_CLUBS = new Card(CardType.QUEEN, Suit.CLUBS, 12);
            this.JACK_OF_CLUBS = new Card(CardType.JACK, Suit.CLUBS, 11);
            this.TEN_OF_CLUBS = new Card(CardType.TEN, Suit.CLUBS, 10);
            this.NINE_OF_CLUBS = new Card(CardType.NINE, Suit.CLUBS, 9);
            this.EIGHT_OF_CLUBS = new Card(CardType.EIGHT, Suit.CLUBS, 8);
            this.SEVEN_OF_CLUBS = new Card(CardType.SEVEN, Suit.CLUBS, 7);
            this.SIX_OF_CLUBS = new Card(CardType.SIX, Suit.CLUBS, 6);
            this.FIVE_OF_CLUBS = new Card(CardType.FIVE, Suit.CLUBS, 5);
            this.FOUR_OF_CLUBS = new Card(CardType.FOUR, Suit.CLUBS, 4);
            this.THREE_OF_CLUBS = new Card(CardType.THREE, Suit.CLUBS, 3);
            this.TWO_OF_CLUBS = new Card(CardType.TWO, Suit.CLUBS, 2);
            this.ACE_OF_HEARTS = new Card(CardType.ACE, Suit.HEARTS, 14, 1);
            this.KING_OF_HEARTS = new Card(CardType.KING, Suit.HEARTS, 13);
            this.QUEEN_OF_HEARTS = new Card(CardType.QUEEN, Suit.HEARTS, 12);
            this.JACK_OF_HEARTS = new Card(CardType.JACK, Suit.HEARTS, 11);
            this.TEN_OF_HEARTS = new Card(CardType.TEN, Suit.HEARTS, 10);
            this.NINE_OF_HEARTS = new Card(CardType.NINE, Suit.HEARTS, 9);
            this.EIGHT_OF_HEARTS = new Card(CardType.EIGHT, Suit.HEARTS, 8);
            this.SEVEN_OF_HEARTS = new Card(CardType.SEVEN, Suit.HEARTS, 7);
            this.SIX_OF_HEARTS = new Card(CardType.SIX, Suit.HEARTS, 6);
            this.FIVE_OF_HEARTS = new Card(CardType.FIVE, Suit.HEARTS, 5);
            this.FOUR_OF_HEARTS = new Card(CardType.FOUR, Suit.HEARTS, 4);
            this.THREE_OF_HEARTS = new Card(CardType.THREE, Suit.HEARTS, 3);
            this.TWO_OF_HEARTS = new Card(CardType.TWO, Suit.HEARTS, 2);
            this.ACE_OF_DIAMONDS = new Card(CardType.ACE, Suit.DIAMONDS, 14, 1);
            this.KING_OF_DIAMONDS = new Card(CardType.KING, Suit.DIAMONDS, 13);
            this.QUEEN_OF_DIAMONDS = new Card(CardType.QUEEN, Suit.DIAMONDS, 12);
            this.JACK_OF_DIAMONDS = new Card(CardType.JACK, Suit.DIAMONDS, 11);
            this.TEN_OF_DIAMONDS = new Card(CardType.TEN, Suit.DIAMONDS, 10);
            this.NINE_OF_DIAMONDS = new Card(CardType.NINE, Suit.DIAMONDS, 9);
            this.EIGHT_OF_DIAMONDS = new Card(CardType.EIGHT, Suit.DIAMONDS, 8);
            this.SEVEN_OF_DIAMONDS = new Card(CardType.SEVEN, Suit.DIAMONDS, 7);
            this.SIX_OF_DIAMONDS = new Card(CardType.SIX, Suit.DIAMONDS, 6);
            this.FIVE_OF_DIAMONDS = new Card(CardType.FIVE, Suit.DIAMONDS, 5);
            this.FOUR_OF_DIAMONDS = new Card(CardType.FOUR, Suit.DIAMONDS, 4);
            this.THREE_OF_DIAMONDS = new Card(CardType.THREE, Suit.DIAMONDS, 3);
            this.TWO_OF_DIAMONDS = new Card(CardType.TWO, Suit.DIAMONDS, 2);
            this.ACE_OF_SPADES = new Card(CardType.ACE, Suit.SPADES, 14, 1);
            this.KING_OF_SPADES = new Card(CardType.KING, Suit.SPADES, 13);
            this.QUEEN_OF_SPADES = new Card(CardType.QUEEN, Suit.SPADES, 12);
            this.JACK_OF_SPADES = new Card(CardType.JACK, Suit.SPADES, 11);
            this.TEN_OF_SPADES = new Card(CardType.TEN, Suit.SPADES, 10);
            this.NINE_OF_SPADES = new Card(CardType.NINE, Suit.SPADES, 9);
            this.EIGHT_OF_SPADES = new Card(CardType.EIGHT, Suit.SPADES, 8);
            this.SEVEN_OF_SPADES = new Card(CardType.SEVEN, Suit.SPADES, 7);
            this.SIX_OF_SPADES = new Card(CardType.SIX, Suit.SPADES, 6);
            this.FIVE_OF_SPADES = new Card(CardType.FIVE, Suit.SPADES, 5);
            this.FOUR_OF_SPADES = new Card(CardType.FOUR, Suit.SPADES, 4);
            this.THREE_OF_SPADES = new Card(CardType.THREE, Suit.SPADES, 3);
            this.TWO_OF_SPADES = new Card(CardType.TWO, Suit.SPADES, 2);

            this.deck = new HashSet<Card> {
                { ACE_OF_CLUBS },
                { KING_OF_CLUBS },
                { QUEEN_OF_CLUBS },
                { JACK_OF_CLUBS },
                { TEN_OF_CLUBS },
                { NINE_OF_CLUBS },
                { EIGHT_OF_CLUBS },
                { SEVEN_OF_CLUBS },
                { SIX_OF_CLUBS },
                { FIVE_OF_CLUBS },
                { FOUR_OF_CLUBS },
                { THREE_OF_CLUBS },
                { TWO_OF_CLUBS },
                { ACE_OF_HEARTS },
                { KING_OF_HEARTS },
                { QUEEN_OF_HEARTS },
                { JACK_OF_HEARTS },
                { TEN_OF_HEARTS },
                { NINE_OF_HEARTS },
                { EIGHT_OF_HEARTS },
                { SEVEN_OF_HEARTS },
                { SIX_OF_HEARTS },
                { FIVE_OF_HEARTS },
                { FOUR_OF_HEARTS },
                { THREE_OF_HEARTS },
                { TWO_OF_HEARTS },
                { ACE_OF_DIAMONDS },
                { KING_OF_DIAMONDS },
                { QUEEN_OF_DIAMONDS },
                { JACK_OF_DIAMONDS },
                { TEN_OF_DIAMONDS },
                { NINE_OF_DIAMONDS },
                { EIGHT_OF_DIAMONDS },
                { SEVEN_OF_DIAMONDS },
                { SIX_OF_DIAMONDS },
                { FIVE_OF_DIAMONDS },
                { FOUR_OF_DIAMONDS },
                { THREE_OF_DIAMONDS },
                { TWO_OF_DIAMONDS },
                { ACE_OF_SPADES },
                { KING_OF_SPADES },
                { QUEEN_OF_SPADES },
                { JACK_OF_SPADES },
                { TEN_OF_SPADES },
                { NINE_OF_SPADES },
                { EIGHT_OF_SPADES },
                { SEVEN_OF_SPADES },
                { SIX_OF_SPADES },
                { FIVE_OF_SPADES },
                { FOUR_OF_SPADES },
                { THREE_OF_SPADES },
                { TWO_OF_SPADES },
            };*/




        }


    }
}
