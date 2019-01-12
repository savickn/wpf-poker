using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole { 
    public static class Data {
        public static readonly Card ACE_OF_CLUBS = new Card("AC.jpg", CardType.ACE, Suit.CLUBS, 14, 1);
        public static readonly Card KING_OF_CLUBS = new Card("KC.jpg", CardType.KING, Suit.CLUBS, 13);
        public static readonly Card QUEEN_OF_CLUBS = new Card("QC.jpg", CardType.QUEEN, Suit.CLUBS, 12);
        public static readonly Card JACK_OF_CLUBS = new Card("JC.jpg", CardType.JACK, Suit.CLUBS, 11);
        public static readonly Card TEN_OF_CLUBS = new Card("TC.jpg", CardType.TEN, Suit.CLUBS, 10);
        public static readonly Card NINE_OF_CLUBS = new Card("9C.jpg", CardType.NINE, Suit.CLUBS, 9);
        public static readonly Card EIGHT_OF_CLUBS = new Card("8C.jpg", CardType.EIGHT, Suit.CLUBS, 8);
        public static readonly Card SEVEN_OF_CLUBS = new Card("7C.jpg", CardType.SEVEN, Suit.CLUBS, 7);
        public static readonly Card SIX_OF_CLUBS = new Card("6C.jpg", CardType.SIX, Suit.CLUBS, 6);
        public static readonly Card FIVE_OF_CLUBS = new Card("5C.jpg", CardType.FIVE, Suit.CLUBS, 5);
        public static readonly Card FOUR_OF_CLUBS = new Card("4C.jpg", CardType.FOUR, Suit.CLUBS, 4);
        public static readonly Card THREE_OF_CLUBS = new Card("3C.jpg", CardType.THREE, Suit.CLUBS, 3);
        public static readonly Card TWO_OF_CLUBS = new Card("2C.jpg", CardType.TWO, Suit.CLUBS, 2);
        public static readonly Card ACE_OF_HEARTS = new Card("AH.jpg", CardType.ACE, Suit.HEARTS, 14, 1);
        public static readonly Card KING_OF_HEARTS = new Card("KH.jpg", CardType.KING, Suit.HEARTS, 13);
        public static readonly Card QUEEN_OF_HEARTS = new Card("QH.jpg", CardType.QUEEN, Suit.HEARTS, 12);
        public static readonly Card JACK_OF_HEARTS = new Card("JH.jpg", CardType.JACK, Suit.HEARTS, 11);
        public static readonly Card TEN_OF_HEARTS = new Card("TH.jpg", CardType.TEN, Suit.HEARTS, 10);
        public static readonly Card NINE_OF_HEARTS = new Card("9H.jpg", CardType.NINE, Suit.HEARTS, 9);
        public static readonly Card EIGHT_OF_HEARTS = new Card("8H.jpg", CardType.EIGHT, Suit.HEARTS, 8);
        public static readonly Card SEVEN_OF_HEARTS = new Card("7H.jpg", CardType.SEVEN, Suit.HEARTS, 7);
        public static readonly Card SIX_OF_HEARTS = new Card("6H.jpg", CardType.SIX, Suit.HEARTS, 6);
        public static readonly Card FIVE_OF_HEARTS = new Card("5H.jpg", CardType.FIVE, Suit.HEARTS, 5);
        public static readonly Card FOUR_OF_HEARTS = new Card("4H.jpg", CardType.FOUR, Suit.HEARTS, 4);
        public static readonly Card THREE_OF_HEARTS = new Card("3H.jpg", CardType.THREE, Suit.HEARTS, 3);
        public static readonly Card TWO_OF_HEARTS = new Card("2H.jpg", CardType.TWO, Suit.HEARTS, 2);
        public static readonly Card ACE_OF_DIAMONDS = new Card("AD.jpg", CardType.ACE, Suit.DIAMONDS, 14, 1);
        public static readonly Card KING_OF_DIAMONDS = new Card("KD.jpg", CardType.KING, Suit.DIAMONDS, 13);
        public static readonly Card QUEEN_OF_DIAMONDS = new Card("QD.jpg", CardType.QUEEN, Suit.DIAMONDS, 12);
        public static readonly Card JACK_OF_DIAMONDS = new Card("JD.jpg", CardType.JACK, Suit.DIAMONDS, 11);
        public static readonly Card TEN_OF_DIAMONDS = new Card("TD.jpg", CardType.TEN, Suit.DIAMONDS, 10);
        public static readonly Card NINE_OF_DIAMONDS = new Card("9D.jpg", CardType.NINE, Suit.DIAMONDS, 9);
        public static readonly Card EIGHT_OF_DIAMONDS = new Card("8D.jpg", CardType.EIGHT, Suit.DIAMONDS, 8);
        public static readonly Card SEVEN_OF_DIAMONDS = new Card("7D.jpg", CardType.SEVEN, Suit.DIAMONDS, 7);
        public static readonly Card SIX_OF_DIAMONDS = new Card("6D.jpg", CardType.SIX, Suit.DIAMONDS, 6);
        public static readonly Card FIVE_OF_DIAMONDS = new Card("5D.jpg", CardType.FIVE, Suit.DIAMONDS, 5);
        public static readonly Card FOUR_OF_DIAMONDS = new Card("4D.jpg", CardType.FOUR, Suit.DIAMONDS, 4);
        public static readonly Card THREE_OF_DIAMONDS = new Card("3D.jpg", CardType.THREE, Suit.DIAMONDS, 3);
        public static readonly Card TWO_OF_DIAMONDS = new Card("2D.jpg", CardType.TWO, Suit.DIAMONDS, 2);
        public static readonly Card ACE_OF_SPADES = new Card("AS.jpg", CardType.ACE, Suit.SPADES, 14, 1);
        public static readonly Card KING_OF_SPADES = new Card("KS.jpg", CardType.KING, Suit.SPADES, 13);
        public static readonly Card QUEEN_OF_SPADES = new Card("QS.jpg", CardType.QUEEN, Suit.SPADES, 12);
        public static readonly Card JACK_OF_SPADES = new Card("JS.jpg", CardType.JACK, Suit.SPADES, 11);
        public static readonly Card TEN_OF_SPADES = new Card("TS.jpg", CardType.TEN, Suit.SPADES, 10);
        public static readonly Card NINE_OF_SPADES = new Card("9S.jpg", CardType.NINE, Suit.SPADES, 9);
        public static readonly Card EIGHT_OF_SPADES = new Card("8S.jpg", CardType.EIGHT, Suit.SPADES, 8);
        public static readonly Card SEVEN_OF_SPADES = new Card("7S.jpg", CardType.SEVEN, Suit.SPADES, 7);
        public static readonly Card SIX_OF_SPADES = new Card("6S.jpg", CardType.SIX, Suit.SPADES, 6);
        public static readonly Card FIVE_OF_SPADES = new Card("5S.jpg", CardType.FIVE, Suit.SPADES, 5);
        public static readonly Card FOUR_OF_SPADES = new Card("4S.jpg", CardType.FOUR, Suit.SPADES, 4);
        public static readonly Card THREE_OF_SPADES = new Card("3S.jpg", CardType.THREE, Suit.SPADES, 3);
        public static readonly Card TWO_OF_SPADES = new Card("2S.jpg", CardType.TWO, Suit.SPADES, 2);

        // used to return a full copy of all Cards in a HashSet
        public static readonly HashSet<Card> deck = new HashSet<Card> {
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
        };

        // used for comparing Suits in the event of a tie (for WarGame)
        private static Dictionary<Suit, int> suitRankings = new Dictionary<Suit, int> {
            { Suit.CLUBS, 1 },
            { Suit.DIAMONDS, 2 },
            { Suit.HEARTS, 3 },
            { Suit.SPADES, 4 }
        };

        // used to compare the value of various Draw types
        private static Dictionary<string, int> drawRankings = new Dictionary<string, int> {
            { "SetFH", 9 },
            { "TPFH", 8 },
            { "Flush", 7 },
            { "OpenEnder", 6 },
            { "Gutshot", 5 },
            { "BackdoorFD", 4 },
            { "BackdoorOE", 3 },
            { "Overcard", 2 },
            { "BackdoorGutshot", 1 }
        };

        // used to compare the value of various MadeHand types
        private static Dictionary<string, int> prefixRankings = new Dictionary<string, int> {
            { "Z", 9 },
            { "Q", 8 },
            { "B", 7 },
            { "F", 6 },
            { "S", 5 },
            { "T", 4 },
            { "W", 3 },
            { "P", 2 },
            { "C", 1 },
            { "N", 0 }
        };
        
        // used to map an initial to every CardType (e.g. CardType.Ace == "A")
        private static Dictionary<CardType, string> initials = new Dictionary<CardType, string> {
            { CardType.ACE, "A" },
            { CardType.KING, "K" },
            { CardType.QUEEN, "Q" },
            { CardType.JACK, "J" },
            { CardType.TEN, "T" },
            { CardType.NINE, "9" },
            { CardType.EIGHT, "8" },
            { CardType.SEVEN, "7" },
            { CardType.SIX, "6" },
            { CardType.FIVE, "5" },
            { CardType.FOUR, "4" },
            { CardType.THREE, "3" },
            { CardType.TWO, "2" },
        };

        private static Dictionary<string, string> prefixes = new Dictionary<string, string> {
            { "Straight Flush", "Z" },
            { "Quads", "Q" },
            { "Full House", "B" },
            { "Flush", "F" },
            { "Straight", "S" },
            { "Trips", "T" },
            { "Two Pair", "W" },
            { "Pair", "P" },
            { "High Card", "C" },
            { "Null Hand", "N" }
        };

        public static Dictionary<Suit, HashSet<Card>> suits = new Dictionary<Suit, HashSet<Card>>() {
            { Suit.CLUBS, new HashSet<Card>() { ACE_OF_CLUBS, KING_OF_CLUBS, QUEEN_OF_CLUBS, JACK_OF_CLUBS, TEN_OF_CLUBS, NINE_OF_CLUBS, EIGHT_OF_CLUBS, SEVEN_OF_CLUBS, SIX_OF_CLUBS, FIVE_OF_CLUBS, FOUR_OF_CLUBS, THREE_OF_CLUBS, TWO_OF_CLUBS } },
            { Suit.DIAMONDS, new HashSet<Card>() { ACE_OF_DIAMONDS, KING_OF_DIAMONDS, QUEEN_OF_DIAMONDS, JACK_OF_DIAMONDS, TEN_OF_DIAMONDS, NINE_OF_DIAMONDS, EIGHT_OF_DIAMONDS, SEVEN_OF_DIAMONDS, SIX_OF_DIAMONDS, FIVE_OF_DIAMONDS, FOUR_OF_DIAMONDS, THREE_OF_DIAMONDS, TWO_OF_DIAMONDS } },
            { Suit.SPADES, new HashSet<Card>() { ACE_OF_SPADES, KING_OF_SPADES, QUEEN_OF_SPADES, JACK_OF_SPADES, TEN_OF_SPADES, NINE_OF_SPADES, EIGHT_OF_SPADES, SEVEN_OF_SPADES, SIX_OF_SPADES, FIVE_OF_SPADES, FOUR_OF_SPADES, THREE_OF_SPADES, TWO_OF_SPADES } },
            { Suit.HEARTS, new HashSet<Card>() { ACE_OF_HEARTS, KING_OF_HEARTS, QUEEN_OF_HEARTS, JACK_OF_HEARTS, TEN_OF_HEARTS, NINE_OF_HEARTS, EIGHT_OF_HEARTS, SEVEN_OF_HEARTS, SIX_OF_HEARTS, FIVE_OF_HEARTS, FOUR_OF_HEARTS, THREE_OF_HEARTS, TWO_OF_HEARTS } },
        };

        public static Dictionary<CardType, HashSet<Card>> types = new Dictionary<CardType, HashSet<Card>>() {
            { CardType.ACE, new HashSet<Card>() { ACE_OF_CLUBS, ACE_OF_DIAMONDS, ACE_OF_HEARTS, ACE_OF_SPADES } },
            { CardType.KING, new HashSet<Card>() { KING_OF_CLUBS, KING_OF_DIAMONDS, KING_OF_HEARTS, KING_OF_SPADES } },
            { CardType.QUEEN, new HashSet<Card>() { QUEEN_OF_CLUBS, QUEEN_OF_DIAMONDS, QUEEN_OF_HEARTS, QUEEN_OF_SPADES } },
            { CardType.JACK, new HashSet<Card>() { JACK_OF_CLUBS, JACK_OF_DIAMONDS, JACK_OF_HEARTS, JACK_OF_SPADES } },
            { CardType.TEN, new HashSet<Card>() { TEN_OF_CLUBS, TEN_OF_DIAMONDS, TEN_OF_HEARTS, TEN_OF_SPADES } },
            { CardType.NINE, new HashSet<Card>() { NINE_OF_CLUBS, NINE_OF_DIAMONDS, NINE_OF_HEARTS, NINE_OF_SPADES } },
            { CardType.EIGHT, new HashSet<Card>() { EIGHT_OF_CLUBS, EIGHT_OF_DIAMONDS, EIGHT_OF_HEARTS, EIGHT_OF_SPADES } },
            { CardType.SEVEN, new HashSet<Card>() { SEVEN_OF_CLUBS, SEVEN_OF_DIAMONDS, SEVEN_OF_HEARTS, SEVEN_OF_SPADES } },
            { CardType.SIX, new HashSet<Card>() { SIX_OF_CLUBS, SIX_OF_DIAMONDS, SIX_OF_HEARTS, SIX_OF_SPADES } },
            { CardType.FIVE, new HashSet<Card>() { FIVE_OF_CLUBS, FIVE_OF_DIAMONDS, FIVE_OF_HEARTS, FIVE_OF_SPADES } },
            { CardType.FOUR, new HashSet<Card>() { FOUR_OF_CLUBS, FOUR_OF_DIAMONDS, FOUR_OF_HEARTS, FOUR_OF_SPADES } },
            { CardType.THREE, new HashSet<Card>() { THREE_OF_CLUBS, THREE_OF_DIAMONDS, THREE_OF_HEARTS, THREE_OF_SPADES } },
            { CardType.TWO, new HashSet<Card>() { TWO_OF_CLUBS, TWO_OF_DIAMONDS, TWO_OF_HEARTS, TWO_OF_SPADES } },
        };

        /* GETTERS and SETTERS */

        static Data() {}

        public static HashSet<Card> getCardsBySuit(Suit s) {
            return suits[s];
        }

        public static HashSet<Card> getCardsByType(CardType ct) {
            return types[ct];
        }

        public static int getSuitRanking(Suit s) {
            return Data.suitRankings[s];
        }

        public static int getDrawRanking(string key) {
            return Data.drawRankings[key];
        }

        public static string getInitial(CardType key) {
            return Data.initials[key];
        }

        public static string getHandPrefix(string key) {
            return Data.prefixes[key];
        }

        public static int getHandRanking(string key) {
            return Data.prefixRankings[key];
        }

        public static HashSet<Card> getDeck() {
            HashSet<Card> cards = new HashSet<Card>();
            foreach(Card c in deck) {
                cards.Add(c.clone());
            }
            return cards;
        }

        public static Card getRandomCard() {
            Random random = new Random();
            int randomNumber = random.Next(0, 52);
            return Data.deck.ElementAt(randomNumber).clone();
        }

    }
}

/*
public static readonly HashSet<Card> deck = new HashSet<Card> {
    { new Card(CardType.ACE, Suit.CLUBS, 14, 1) },
    { new Card(CardType.KING, Suit.CLUBS, 13) },
    { new Card(CardType.QUEEN, Suit.CLUBS, 12) },
    { new Card(CardType.JACK, Suit.CLUBS, 11) },
    { new Card(CardType.TEN, Suit.CLUBS, 10) },
    { new Card(CardType.NINE, Suit.CLUBS, 9) },
    { new Card(CardType.EIGHT, Suit.CLUBS, 8) },
    { new Card(CardType.SEVEN, Suit.CLUBS, 7) },
    { new Card(CardType.SIX, Suit.CLUBS, 6) },
    { new Card(CardType.FIVE, Suit.CLUBS, 5) },
    { new Card(CardType.FOUR, Suit.CLUBS, 4) },
    { new Card(CardType.THREE, Suit.CLUBS, 3) },
    { new Card(CardType.TWO, Suit.CLUBS, 2) },
    { new Card(CardType.ACE, Suit.HEARTS, 14, 1) },
    { new Card(CardType.KING, Suit.HEARTS, 13) },
    { new Card(CardType.QUEEN, Suit.HEARTS, 12) },
    { new Card(CardType.JACK, Suit.HEARTS, 11) },
    { new Card(CardType.TEN, Suit.HEARTS, 10) },
    { new Card(CardType.NINE, Suit.HEARTS, 9) },
    { new Card(CardType.EIGHT, Suit.HEARTS, 8) },
    { new Card(CardType.SEVEN, Suit.HEARTS, 7) },
    { new Card(CardType.SIX, Suit.HEARTS, 6) },
    { new Card(CardType.FIVE, Suit.HEARTS, 5) },
    { new Card(CardType.FOUR, Suit.HEARTS, 4) },
    { new Card(CardType.THREE, Suit.HEARTS, 3) },
    { new Card(CardType.TWO, Suit.HEARTS, 2) },
    { new Card(CardType.ACE, Suit.DIAMONDS, 14, 1) },
    { new Card(CardType.KING, Suit.DIAMONDS, 13) },
    { new Card(CardType.QUEEN, Suit.DIAMONDS, 12) },
    { new Card(CardType.JACK, Suit.DIAMONDS, 11) },
    { new Card(CardType.TEN, Suit.DIAMONDS, 10) },
    { new Card(CardType.NINE, Suit.DIAMONDS, 9) },
    { new Card(CardType.EIGHT, Suit.DIAMONDS, 8) },
    { new Card(CardType.SEVEN, Suit.DIAMONDS, 7) },
    { new Card(CardType.SIX, Suit.DIAMONDS, 6) },
    { new Card(CardType.FIVE, Suit.DIAMONDS, 5) },
    { new Card(CardType.FOUR, Suit.DIAMONDS, 4) },
    { new Card(CardType.THREE, Suit.DIAMONDS, 3) },
    { new Card(CardType.TWO, Suit.DIAMONDS, 2) },
    { new Card(CardType.ACE, Suit.SPADES, 14, 1) },
    { new Card(CardType.KING, Suit.SPADES, 13) },
    { new Card(CardType.QUEEN, Suit.SPADES, 12) },
    { new Card(CardType.JACK, Suit.SPADES, 11) },
    { new Card(CardType.TEN, Suit.SPADES, 10) },
    { new Card(CardType.NINE, Suit.SPADES, 9) },
    { new Card(CardType.EIGHT, Suit.SPADES, 8) },
    { new Card(CardType.SEVEN, Suit.SPADES, 7) },
    { new Card(CardType.SIX, Suit.SPADES, 6) },
    { new Card(CardType.FIVE, Suit.SPADES, 5) },
    { new Card(CardType.FOUR, Suit.SPADES, 4) },
    { new Card(CardType.THREE, Suit.SPADES, 3) },
    { new Card(CardType.TWO, Suit.SPADES, 2) },
};
 
public static readonly Card ACE_OF_CLUBS = new Card("AC.jpg", CardType.ACE, Suit.CLUBS, 14, 1);
public static readonly Card KING_OF_CLUBS = new Card("KC.jpg", CardType.KING, Suit.CLUBS, 13);
public static readonly Card QUEEN_OF_CLUBS = new Card("QC.jpg", CardType.QUEEN, Suit.CLUBS, 12);
public static readonly Card JACK_OF_CLUBS = new Card("JC.jpg", CardType.JACK, Suit.CLUBS, 11);
public static readonly Card TEN_OF_CLUBS = new Card("TC.jpg", CardType.TEN, Suit.CLUBS, 10);
public static readonly Card NINE_OF_CLUBS = new Card("9C.jpg", CardType.NINE, Suit.CLUBS, 9);
public static readonly Card EIGHT_OF_CLUBS = new Card("8C.jpg", CardType.EIGHT, Suit.CLUBS, 8);
public static readonly Card SEVEN_OF_CLUBS = new Card("7C.jpg", CardType.SEVEN, Suit.CLUBS, 7);
public static readonly Card SIX_OF_CLUBS = new Card("6C.jpg", CardType.SIX, Suit.CLUBS, 6);
public static readonly Card FIVE_OF_CLUBS = new Card("5C.jpg", CardType.FIVE, Suit.CLUBS, 5);
public static readonly Card FOUR_OF_CLUBS = new Card("4C.jpg", CardType.FOUR, Suit.CLUBS, 4);
public static readonly Card THREE_OF_CLUBS = new Card("3C.jpg", CardType.THREE, Suit.CLUBS, 3);
public static readonly Card TWO_OF_CLUBS = new Card("2C.jpg", CardType.TWO, Suit.CLUBS, 2);
public static readonly Card ACE_OF_HEARTS = new Card("AH.jpg", CardType.ACE, Suit.HEARTS, 14, 1);
public static readonly Card KING_OF_HEARTS = new Card("KH.jpg", CardType.KING, Suit.HEARTS, 13);
public static readonly Card QUEEN_OF_HEARTS = new Card("QH.jpg", CardType.QUEEN, Suit.HEARTS, 12);
public static readonly Card JACK_OF_HEARTS = new Card("JH.jpg", CardType.JACK, Suit.HEARTS, 11);
public static readonly Card TEN_OF_HEARTS = new Card("TH.jpg", CardType.TEN, Suit.HEARTS, 10);
public static readonly Card NINE_OF_HEARTS = new Card("9H.jpg", CardType.NINE, Suit.HEARTS, 9);
public static readonly Card EIGHT_OF_HEARTS = new Card("8H.jpg", CardType.EIGHT, Suit.HEARTS, 8);
public static readonly Card SEVEN_OF_HEARTS = new Card("7H.jpg", CardType.SEVEN, Suit.HEARTS, 7);
public static readonly Card SIX_OF_HEARTS = new Card("6H.jpg", CardType.SIX, Suit.HEARTS, 6);
public static readonly Card FIVE_OF_HEARTS = new Card("5H.jpg", CardType.FIVE, Suit.HEARTS, 5);
public static readonly Card FOUR_OF_HEARTS = new Card("4H.jpg", CardType.FOUR, Suit.HEARTS, 4);
public static readonly Card THREE_OF_HEARTS = new Card("3H.jpg", CardType.THREE, Suit.HEARTS, 3);
public static readonly Card TWO_OF_HEARTS = new Card("2H.jpg", CardType.TWO, Suit.HEARTS, 2);
public static readonly Card ACE_OF_DIAMONDS = new Card("AD.jpg", CardType.ACE, Suit.DIAMONDS, 14, 1);
public static readonly Card KING_OF_DIAMONDS = new Card("KD.jpg", CardType.KING, Suit.DIAMONDS, 13);
public static readonly Card QUEEN_OF_DIAMONDS = new Card("QD.jpg", CardType.QUEEN, Suit.DIAMONDS, 12);
public static readonly Card JACK_OF_DIAMONDS = new Card("JD.jpg", CardType.JACK, Suit.DIAMONDS, 11);
public static readonly Card TEN_OF_DIAMONDS = new Card("TD.jpg", CardType.TEN, Suit.DIAMONDS, 10);
public static readonly Card NINE_OF_DIAMONDS = new Card("9D.jpg", CardType.NINE, Suit.DIAMONDS, 9);
public static readonly Card EIGHT_OF_DIAMONDS = new Card("8D.jpg", CardType.EIGHT, Suit.DIAMONDS, 8);
public static readonly Card SEVEN_OF_DIAMONDS = new Card("7D.jpg", CardType.SEVEN, Suit.DIAMONDS, 7);
public static readonly Card SIX_OF_DIAMONDS = new Card("6D.jpg", CardType.SIX, Suit.DIAMONDS, 6);
public static readonly Card FIVE_OF_DIAMONDS = new Card("5D.jpg", CardType.FIVE, Suit.DIAMONDS, 5);
public static readonly Card FOUR_OF_DIAMONDS = new Card("4D.jpg", CardType.FOUR, Suit.DIAMONDS, 4);
public static readonly Card THREE_OF_DIAMONDS = new Card("3D.jpg", CardType.THREE, Suit.DIAMONDS, 3);
public static readonly Card TWO_OF_DIAMONDS = new Card("2D.jpg", CardType.TWO, Suit.DIAMONDS, 2);
public static readonly Card ACE_OF_SPADES = new Card("AS.jpg", CardType.ACE, Suit.SPADES, 14, 1);
public static readonly Card KING_OF_SPADES = new Card("KS.jpg", CardType.KING, Suit.SPADES, 13);
public static readonly Card QUEEN_OF_SPADES = new Card("QS.jpg", CardType.QUEEN, Suit.SPADES, 12);
public static readonly Card JACK_OF_SPADES = new Card("JS.jpg", CardType.JACK, Suit.SPADES, 11);
public static readonly Card TEN_OF_SPADES = new Card("TS.jpg", CardType.TEN, Suit.SPADES, 10);
public static readonly Card NINE_OF_SPADES = new Card("9S.jpg", CardType.NINE, Suit.SPADES, 9);
public static readonly Card EIGHT_OF_SPADES = new Card("8S.jpg", CardType.EIGHT, Suit.SPADES, 8);
public static readonly Card SEVEN_OF_SPADES = new Card("7S.jpg", CardType.SEVEN, Suit.SPADES, 7);
public static readonly Card SIX_OF_SPADES = new Card("6S.jpg", CardType.SIX, Suit.SPADES, 6);
public static readonly Card FIVE_OF_SPADES = new Card("5S.jpg", CardType.FIVE, Suit.SPADES, 5);
public static readonly Card FOUR_OF_SPADES = new Card("4S.jpg", CardType.FOUR, Suit.SPADES, 4);
public static readonly Card THREE_OF_SPADES = new Card("3S.jpg", CardType.THREE, Suit.SPADES, 3);
public static readonly Card TWO_OF_SPADES = new Card("2S.jpg", CardType.TWO, Suit.SPADES, 2);
    
public static readonly Card ACE_OF_CLUBS = new Card("ace_of_clubs.jpg", CardType.ACE, Suit.CLUBS, 14, 1);
public static readonly Card KING_OF_CLUBS = new Card("king_of_clubs.jpg", CardType.KING, Suit.CLUBS, 13);
public static readonly Card QUEEN_OF_CLUBS = new Card("queen_of_clubs.jpg", CardType.QUEEN, Suit.CLUBS, 12);
public static readonly Card JACK_OF_CLUBS = new Card("jack_of_clubs.jpg", CardType.JACK, Suit.CLUBS, 11);
public static readonly Card TEN_OF_CLUBS = new Card("10_of_clubs.jpg", CardType.TEN, Suit.CLUBS, 10);
public static readonly Card NINE_OF_CLUBS = new Card("9_of_clubs.jpg", CardType.NINE, Suit.CLUBS, 9);
public static readonly Card EIGHT_OF_CLUBS = new Card("8_of_clubs.jpg", CardType.EIGHT, Suit.CLUBS, 8);
public static readonly Card SEVEN_OF_CLUBS = new Card("7_of_clubs.jpg", CardType.SEVEN, Suit.CLUBS, 7);
public static readonly Card SIX_OF_CLUBS = new Card("6_of_clubs.jpg", CardType.SIX, Suit.CLUBS, 6);
public static readonly Card FIVE_OF_CLUBS = new Card("5_of_clubs.jpg", CardType.FIVE, Suit.CLUBS, 5);
public static readonly Card FOUR_OF_CLUBS = new Card("4_of_clubs.jpg", CardType.FOUR, Suit.CLUBS, 4);
public static readonly Card THREE_OF_CLUBS = new Card("3_of_clubs.jpg", CardType.THREE, Suit.CLUBS, 3);
public static readonly Card TWO_OF_CLUBS = new Card("2_of_clubs.jpg", CardType.TWO, Suit.CLUBS, 2);
public static readonly Card ACE_OF_HEARTS = new Card("ace_of_hearts.jpg", CardType.ACE, Suit.HEARTS, 14, 1);
public static readonly Card KING_OF_HEARTS = new Card("king_of_hearts.jpg", CardType.KING, Suit.HEARTS, 13);
public static readonly Card QUEEN_OF_HEARTS = new Card("queen_of_hearts.jpg", CardType.QUEEN, Suit.HEARTS, 12);
public static readonly Card JACK_OF_HEARTS = new Card("jack_of_hearts.jpg", CardType.JACK, Suit.HEARTS, 11);
public static readonly Card TEN_OF_HEARTS = new Card("10_of_hearts.jpg", CardType.TEN, Suit.HEARTS, 10);
public static readonly Card NINE_OF_HEARTS = new Card("9_of_hearts.jpg", CardType.NINE, Suit.HEARTS, 9);
public static readonly Card EIGHT_OF_HEARTS = new Card("8_of_hearts.jpg", CardType.EIGHT, Suit.HEARTS, 8);
public static readonly Card SEVEN_OF_HEARTS = new Card("7_of_hearts.jpg", CardType.SEVEN, Suit.HEARTS, 7);
public static readonly Card SIX_OF_HEARTS = new Card("6_of_hearts.jpg", CardType.SIX, Suit.HEARTS, 6);
public static readonly Card FIVE_OF_HEARTS = new Card("5_of_hearts.jpg", CardType.FIVE, Suit.HEARTS, 5);
public static readonly Card FOUR_OF_HEARTS = new Card("4_of_hearts.jpg", CardType.FOUR, Suit.HEARTS, 4);
public static readonly Card THREE_OF_HEARTS = new Card("3_of_hearts.jpg", CardType.THREE, Suit.HEARTS, 3);
public static readonly Card TWO_OF_HEARTS = new Card("2_of_hearts.jpg", CardType.TWO, Suit.HEARTS, 2);
public static readonly Card ACE_OF_DIAMONDS = new Card("ace_of_diamonds.jpg", CardType.ACE, Suit.DIAMONDS, 14, 1);
public static readonly Card KING_OF_DIAMONDS = new Card("king_of_diamonds.jpg", CardType.KING, Suit.DIAMONDS, 13);
public static readonly Card QUEEN_OF_DIAMONDS = new Card("queen_of_diamonds.jpg", CardType.QUEEN, Suit.DIAMONDS, 12);
public static readonly Card JACK_OF_DIAMONDS = new Card("jack_of_diamonds.jpg", CardType.JACK, Suit.DIAMONDS, 11);
public static readonly Card TEN_OF_DIAMONDS = new Card("10_of_diamonds.jpg", CardType.TEN, Suit.DIAMONDS, 10);
public static readonly Card NINE_OF_DIAMONDS = new Card("9_of_diamonds.jpg", CardType.NINE, Suit.DIAMONDS, 9);
public static readonly Card EIGHT_OF_DIAMONDS = new Card("8_of_diamonds.jpg", CardType.EIGHT, Suit.DIAMONDS, 8);
public static readonly Card SEVEN_OF_DIAMONDS = new Card("7_of_diamonds.jpg", CardType.SEVEN, Suit.DIAMONDS, 7);
public static readonly Card SIX_OF_DIAMONDS = new Card("6_of_diamonds.jpg", CardType.SIX, Suit.DIAMONDS, 6);
public static readonly Card FIVE_OF_DIAMONDS = new Card("5_of_diamonds.jpg", CardType.FIVE, Suit.DIAMONDS, 5);
public static readonly Card FOUR_OF_DIAMONDS = new Card("4_of_diamonds.jpg", CardType.FOUR, Suit.DIAMONDS, 4);
public static readonly Card THREE_OF_DIAMONDS = new Card("3_of_diamonds.jpg", CardType.THREE, Suit.DIAMONDS, 3);
public static readonly Card TWO_OF_DIAMONDS = new Card("2_of_diamonds.jpg", CardType.TWO, Suit.DIAMONDS, 2);
public static readonly Card ACE_OF_SPADES = new Card("ace_of_spades.jpg", CardType.ACE, Suit.SPADES, 14, 1);
public static readonly Card KING_OF_SPADES = new Card("king_of_spades.jpg", CardType.KING, Suit.SPADES, 13);
public static readonly Card QUEEN_OF_SPADES = new Card("queen_of_spades.jpg", CardType.QUEEN, Suit.SPADES, 12);
public static readonly Card JACK_OF_SPADES = new Card("jack_of_spades.jpg", CardType.JACK, Suit.SPADES, 11);
public static readonly Card TEN_OF_SPADES = new Card("10_of_spades.jpg", CardType.TEN, Suit.SPADES, 10);
public static readonly Card NINE_OF_SPADES = new Card("9_of_spades.jpg", CardType.NINE, Suit.SPADES, 9);
public static readonly Card EIGHT_OF_SPADES = new Card("8_of_spades.jpg", CardType.EIGHT, Suit.SPADES, 8);
public static readonly Card SEVEN_OF_SPADES = new Card("7_of_spades.jpg", CardType.SEVEN, Suit.SPADES, 7);
public static readonly Card SIX_OF_SPADES = new Card("6_of_spades.jpg", CardType.SIX, Suit.SPADES, 6);
public static readonly Card FIVE_OF_SPADES = new Card("5_of_spades.jpg", CardType.FIVE, Suit.SPADES, 5);
public static readonly Card FOUR_OF_SPADES = new Card("4_of_spades.jpg", CardType.FOUR, Suit.SPADES, 4);
public static readonly Card THREE_OF_SPADES = new Card("3_of_spades.jpg", CardType.THREE, Suit.SPADES, 3);
public static readonly Card TWO_OF_SPADES = new Card("2_of_spades.jpg", CardType.TWO, Suit.SPADES, 2);



    public static readonly List<Card> deck = new List<Card> {
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
        };







    // used to return a full copy of all Cards in a HashSet
        public static readonly HashSet<Card> deck = new HashSet<Card> {
            { ACE_OF_CLUBS.clone() },
            { KING_OF_CLUBS.clone() },
            { QUEEN_OF_CLUBS.clone() },
            { JACK_OF_CLUBS.clone() },
            { TEN_OF_CLUBS.clone() },
            { NINE_OF_CLUBS.clone() },
            { EIGHT_OF_CLUBS.clone() },
            { SEVEN_OF_CLUBS.clone() },
            { SIX_OF_CLUBS.clone() },
            { FIVE_OF_CLUBS.clone() },
            { FOUR_OF_CLUBS.clone() },
            { THREE_OF_CLUBS.clone() },
            { TWO_OF_CLUBS.clone() },
            { ACE_OF_HEARTS.clone() },
            { KING_OF_HEARTS.clone() },
            { QUEEN_OF_HEARTS.clone() },
            { JACK_OF_HEARTS.clone() },
            { TEN_OF_HEARTS.clone() },
            { NINE_OF_HEARTS.clone() },
            { EIGHT_OF_HEARTS.clone() },
            { SEVEN_OF_HEARTS.clone() },
            { SIX_OF_HEARTS.clone() },
            { FIVE_OF_HEARTS.clone() },
            { FOUR_OF_HEARTS.clone() },
            { THREE_OF_HEARTS.clone() },
            { TWO_OF_HEARTS.clone() },
            { ACE_OF_DIAMONDS.clone() },
            { KING_OF_DIAMONDS.clone() },
            { QUEEN_OF_DIAMONDS.clone() },
            { JACK_OF_DIAMONDS.clone() },
            { TEN_OF_DIAMONDS.clone() },
            { NINE_OF_DIAMONDS.clone() },
            { EIGHT_OF_DIAMONDS.clone() },
            { SEVEN_OF_DIAMONDS.clone() },
            { SIX_OF_DIAMONDS.clone() },
            { FIVE_OF_DIAMONDS.clone() },
            { FOUR_OF_DIAMONDS.clone() },
            { THREE_OF_DIAMONDS.clone() },
            { TWO_OF_DIAMONDS.clone() },
            { ACE_OF_SPADES.clone() },
            { KING_OF_SPADES.clone() },
            { QUEEN_OF_SPADES.clone() },
            { JACK_OF_SPADES.clone() },
            { TEN_OF_SPADES.clone() },
            { NINE_OF_SPADES.clone() },
            { EIGHT_OF_SPADES.clone() },
            { SEVEN_OF_SPADES.clone() },
            { SIX_OF_SPADES.clone() },
            { FIVE_OF_SPADES.clone() },
            { FOUR_OF_SPADES.clone() },
            { THREE_OF_SPADES.clone() },
            { TWO_OF_SPADES.clone() },
        };
 */
