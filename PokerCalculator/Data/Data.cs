﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator { 
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

        /*public static Dictionary<string, HashSet<int>> straightInts = new Dictionary<string, HashSet<int>>() {
            { "A-5", new HashSet<int> { 1, 2, 3, 4, 5 } },
            { "2-6", new HashSet<int> { 2, 3, 4, 5, 6 } },
            { "3-7", new HashSet<int> { 3, 4, 5, 6, 7 } },
            { "4-8", new HashSet<int> { 4, 5, 6, 7, 8 } },
            { "5-9", new HashSet<int> { 5, 6, 7, 8, 9 } },
            { "6-T", new HashSet<int> { 6, 7, 8, 9, 10 } },
            { "7-J", new HashSet<int> { 7, 8, 9, 10, 11 } },
            { "8-Q", new HashSet<int> { 8, 9, 10, 11, 12 } },
            { "9-K", new HashSet<int> { 9, 10, 11, 12, 13 } },
            { "T-A", new HashSet<int> { 10, 11, 12, 13, 14 } },
        };*/

        public static Dictionary<string, Straight> straights = new Dictionary<string, Straight>() {
            { "5-High", new Straight(new List<Card>() { ACE_OF_HEARTS, TWO_OF_CLUBS, THREE_OF_DIAMONDS, FOUR_OF_HEARTS, FIVE_OF_SPADES }) },
            { "6-High", new Straight(new List<Card>() { TWO_OF_CLUBS, THREE_OF_DIAMONDS, FOUR_OF_HEARTS, FIVE_OF_SPADES, SIX_OF_HEARTS }) },
            { "7-High", new Straight(new List<Card>() { THREE_OF_DIAMONDS, FOUR_OF_HEARTS, FIVE_OF_SPADES, SIX_OF_HEARTS, SEVEN_OF_CLUBS }) },
            { "8-High", new Straight(new List<Card>() { FOUR_OF_HEARTS, FIVE_OF_SPADES, SIX_OF_HEARTS, SEVEN_OF_CLUBS, EIGHT_OF_DIAMONDS }) },
            { "9-High", new Straight(new List<Card>() { FIVE_OF_SPADES, SIX_OF_HEARTS, SEVEN_OF_CLUBS, EIGHT_OF_DIAMONDS, NINE_OF_DIAMONDS }) },
            { "T-High", new Straight(new List<Card>() { SIX_OF_HEARTS, SEVEN_OF_CLUBS, EIGHT_OF_DIAMONDS, NINE_OF_DIAMONDS, TEN_OF_SPADES }) },
            { "J-High", new Straight(new List<Card>() { SEVEN_OF_CLUBS, EIGHT_OF_DIAMONDS, NINE_OF_DIAMONDS, TEN_OF_SPADES, JACK_OF_HEARTS }) },
            { "Q-High", new Straight(new List<Card>() { EIGHT_OF_DIAMONDS, NINE_OF_DIAMONDS, TEN_OF_SPADES, JACK_OF_HEARTS, QUEEN_OF_CLUBS }) },
            { "K-High", new Straight(new List<Card>() { NINE_OF_DIAMONDS, TEN_OF_SPADES, JACK_OF_HEARTS, QUEEN_OF_CLUBS, KING_OF_HEARTS }) },
            { "A-High", new Straight(new List<Card>() { TEN_OF_SPADES, JACK_OF_HEARTS, QUEEN_OF_CLUBS, KING_OF_HEARTS, ACE_OF_DIAMONDS }) },
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

        static Data() {}

        public static Dictionary<string, Straight> getStraights() {
            return straights;
        }

        public static HashSet<Card> getCardsBySuit(Suit s) {
            return suits[s];
        }

        public static HashSet<Card> getCardsByType(CardType ct) {
            return types[ct];
        }

        public static int getDrawRanking(string key) {
            return Data.drawRankings[key];
        }

        public static string getHandPrefix(string key) {
            return Data.prefixes[key];
        }

        public static int getHandRanking(string key) {
            return Data.prefixRankings[key];
        }

        // returns a deep copy of the entire Deck as a HashSet
        public static HashSet<Card> getDeck() {
            HashSet<Card> cards = new HashSet<Card>();
            foreach (Card c in Data.deck) {
                cards.Add(c.clone());
            }
            return cards;
        }

        // returns a deep copy of a specific Card via its 'id' (e.g. "AsKs")
        public static Card getCardById(string id) {
            throw new NotImplementedException();
        }

        // returns a deep copy of a random Card
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
        
     public static readonly Card ACE_OF_CLUBS = new Card("ace_of_clubs.svg", CardType.ACE, Suit.CLUBS, 14, 1);
        public static readonly Card KING_OF_CLUBS = new Card("king_of_clubs.svg", CardType.KING, Suit.CLUBS, 13);
        public static readonly Card QUEEN_OF_CLUBS = new Card("queen_of_clubs.svg", CardType.QUEEN, Suit.CLUBS, 12);
        public static readonly Card JACK_OF_CLUBS = new Card("jack_of_clubs.svg", CardType.JACK, Suit.CLUBS, 11);
        public static readonly Card TEN_OF_CLUBS = new Card("10_of_clubs.svg", CardType.TEN, Suit.CLUBS, 10);
        public static readonly Card NINE_OF_CLUBS = new Card("9_of_clubs.svg", CardType.NINE, Suit.CLUBS, 9);
        public static readonly Card EIGHT_OF_CLUBS = new Card("8_of_clubs.svg", CardType.EIGHT, Suit.CLUBS, 8);
        public static readonly Card SEVEN_OF_CLUBS = new Card("7_of_clubs.svg", CardType.SEVEN, Suit.CLUBS, 7);
        public static readonly Card SIX_OF_CLUBS = new Card("6_of_clubs.svg", CardType.SIX, Suit.CLUBS, 6);
        public static readonly Card FIVE_OF_CLUBS = new Card("5_of_clubs.svg", CardType.FIVE, Suit.CLUBS, 5);
        public static readonly Card FOUR_OF_CLUBS = new Card("4_of_clubs.svg", CardType.FOUR, Suit.CLUBS, 4);
        public static readonly Card THREE_OF_CLUBS = new Card("3_of_clubs.svg", CardType.THREE, Suit.CLUBS, 3);
        public static readonly Card TWO_OF_CLUBS = new Card("2_of_clubs.svg", CardType.TWO, Suit.CLUBS, 2);
        public static readonly Card ACE_OF_HEARTS = new Card("ace_of_hearts.svg", CardType.ACE, Suit.HEARTS, 14, 1);
        public static readonly Card KING_OF_HEARTS = new Card("king_of_hearts.svg", CardType.KING, Suit.HEARTS, 13);
        public static readonly Card QUEEN_OF_HEARTS = new Card("queen_of_hearts.svg", CardType.QUEEN, Suit.HEARTS, 12);
        public static readonly Card JACK_OF_HEARTS = new Card("jack_of_hearts.svg", CardType.JACK, Suit.HEARTS, 11);
        public static readonly Card TEN_OF_HEARTS = new Card("10_of_hearts.svg", CardType.TEN, Suit.HEARTS, 10);
        public static readonly Card NINE_OF_HEARTS = new Card("9_of_hearts.svg", CardType.NINE, Suit.HEARTS, 9);
        public static readonly Card EIGHT_OF_HEARTS = new Card("8_of_hearts.svg", CardType.EIGHT, Suit.HEARTS, 8);
        public static readonly Card SEVEN_OF_HEARTS = new Card("7_of_hearts.svg", CardType.SEVEN, Suit.HEARTS, 7);
        public static readonly Card SIX_OF_HEARTS = new Card("6_of_hearts.svg", CardType.SIX, Suit.HEARTS, 6);
        public static readonly Card FIVE_OF_HEARTS = new Card("5_of_hearts.svg", CardType.FIVE, Suit.HEARTS, 5);
        public static readonly Card FOUR_OF_HEARTS = new Card("4_of_hearts.svg", CardType.FOUR, Suit.HEARTS, 4);
        public static readonly Card THREE_OF_HEARTS = new Card("3_of_hearts.svg", CardType.THREE, Suit.HEARTS, 3);
        public static readonly Card TWO_OF_HEARTS = new Card("2_of_hearts.svg", CardType.TWO, Suit.HEARTS, 2);
        public static readonly Card ACE_OF_DIAMONDS = new Card("ace_of_diamonds.svg", CardType.ACE, Suit.DIAMONDS, 14, 1);
        public static readonly Card KING_OF_DIAMONDS = new Card("king_of_diamonds.svg", CardType.KING, Suit.DIAMONDS, 13);
        public static readonly Card QUEEN_OF_DIAMONDS = new Card("queen_of_diamonds.svg", CardType.QUEEN, Suit.DIAMONDS, 12);
        public static readonly Card JACK_OF_DIAMONDS = new Card("jack_of_diamonds.svg", CardType.JACK, Suit.DIAMONDS, 11);
        public static readonly Card TEN_OF_DIAMONDS = new Card("10_of_diamonds.svg", CardType.TEN, Suit.DIAMONDS, 10);
        public static readonly Card NINE_OF_DIAMONDS = new Card("9_of_diamonds.svg", CardType.NINE, Suit.DIAMONDS, 9);
        public static readonly Card EIGHT_OF_DIAMONDS = new Card("8_of_diamonds.svg", CardType.EIGHT, Suit.DIAMONDS, 8);
        public static readonly Card SEVEN_OF_DIAMONDS = new Card("7_of_diamonds.svg", CardType.SEVEN, Suit.DIAMONDS, 7);
        public static readonly Card SIX_OF_DIAMONDS = new Card("6_of_diamonds.svg", CardType.SIX, Suit.DIAMONDS, 6);
        public static readonly Card FIVE_OF_DIAMONDS = new Card("5_of_diamonds.svg", CardType.FIVE, Suit.DIAMONDS, 5);
        public static readonly Card FOUR_OF_DIAMONDS = new Card("4_of_diamonds.svg", CardType.FOUR, Suit.DIAMONDS, 4);
        public static readonly Card THREE_OF_DIAMONDS = new Card("3_of_diamonds.svg", CardType.THREE, Suit.DIAMONDS, 3);
        public static readonly Card TWO_OF_DIAMONDS = new Card("2_of_diamonds.svg", CardType.TWO, Suit.DIAMONDS, 2);
        public static readonly Card ACE_OF_SPADES = new Card("ace_of_spades.svg", CardType.ACE, Suit.SPADES, 14, 1);
        public static readonly Card KING_OF_SPADES = new Card("king_of_spades.svg", CardType.KING, Suit.SPADES, 13);
        public static readonly Card QUEEN_OF_SPADES = new Card("queen_of_spades.svg", CardType.QUEEN, Suit.SPADES, 12);
        public static readonly Card JACK_OF_SPADES = new Card("jack_of_spades.svg", CardType.JACK, Suit.SPADES, 11);
        public static readonly Card TEN_OF_SPADES = new Card("10_of_spades.svg", CardType.TEN, Suit.SPADES, 10);
        public static readonly Card NINE_OF_SPADES = new Card("9_of_spades.svg", CardType.NINE, Suit.SPADES, 9);
        public static readonly Card EIGHT_OF_SPADES = new Card("8_of_spades.svg", CardType.EIGHT, Suit.SPADES, 8);
        public static readonly Card SEVEN_OF_SPADES = new Card("7_of_spades.svg", CardType.SEVEN, Suit.SPADES, 7);
        public static readonly Card SIX_OF_SPADES = new Card("6_of_spades.svg", CardType.SIX, Suit.SPADES, 6);
        public static readonly Card FIVE_OF_SPADES = new Card("5_of_spades.svg", CardType.FIVE, Suit.SPADES, 5);
        public static readonly Card FOUR_OF_SPADES = new Card("4_of_spades.svg", CardType.FOUR, Suit.SPADES, 4);
        public static readonly Card THREE_OF_SPADES = new Card("3_of_spades.svg", CardType.THREE, Suit.SPADES, 3);
        public static readonly Card TWO_OF_SPADES = new Card("2_of_spades.svg", CardType.TWO, Suit.SPADES, 2);
     */
