using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator { 
    public static class Data {
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
            { CardType.TWO, "2" }
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

        static Data() {}

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
    }
}
