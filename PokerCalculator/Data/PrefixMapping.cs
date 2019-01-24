using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public static class PrefixMapping {

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

        static PrefixMapping() { }


        // NOT WORKING FOR SOME REASON
        public static string getInitial(CardType key) {
            var i = initials[key];
            return i;
        }
    }
}
