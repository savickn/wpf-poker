using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    static public class FisherYates {
        static Random r = new Random();
        static public void shuffle(List<Card> deck) {
            for (int n = deck.Count - 1; n > 0; --n) {
                int k = r.Next(n + 1);
                Card temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }
    }
}
