using System;
using System.Collections.Generic;

namespace TestConsole {

    class Program {
        static void Main(string[] args) {

            /* tests that Deck.getRandomCard() returns a deep copy, WORKING
            Card c;
            Deck d = new Deck(new HashSet<Card>());

            while (d.length > 0) {
                c = d.getTopCard();
                Console.WriteLine(c.toString());
            }

            Card r = Data.getRandomCard();
            r.Hidden = false;

            Console.WriteLine("-------------");

            d = new Deck(new HashSet<Card>());
            while (d.length > 0) {
                c = d.getTopCard();
                Console.WriteLine(c.toString());
            }
            */

            /* tests that Deck.getDeck() returns a deep copy, WORKING
            Card c;
            Deck d = new Deck(new HashSet<Card>());

            while(d.length > 0) {
                c = d.getTopCard();
                Console.WriteLine(c.toString());
                c.Hidden = false;
            }

            Console.WriteLine("-------------");

            d = new Deck(new HashSet<Card>());
            while (d.length > 0) {
                c = d.getTopCard();
                Console.WriteLine(c.toString());
            }
            */

            /* tests that Card.clone() produces a deep copy, WORKING
            Card ACE_OF_CLUBS = new Card("AC.jpg", CardType.ACE, Suit.CLUBS, 14, 1); 
            Console.WriteLine(ACE_OF_CLUBS.toString());
            Card c2 = ACE_OF_CLUBS.clone();
            c2.suit = Suit.DIAMONDS;
            Console.WriteLine(c2.toString());
            Console.WriteLine(ACE_OF_CLUBS.toString());
            */

            Console.ReadLine();
        }
    }
}
