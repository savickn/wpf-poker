using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator { 
    class Data {
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

        private static Dictionary<string, string> initials = new Dictionary<string, string> {
            { "Ace", "A" },
            { "King", "K" },
            { "Queen", "Q" },
            { "Jack", "J" },
            { "Ten", "T" },
            { "Nine", "9" },
            { "Eight", "8" },
            { "Seven", "7" },
            { "Six", "6" },
            { "Five", "5" },
            { "Four", "4" },
            { "Three", "3" },
            { "Two", "2" }
        };

        private static Dictionary<string, string> prefixes = new Dictionary<string, string> {
            { "Straight Flush", "Z" },
            { "Quads", "Q" },
            { "Full House", "B" },
            { "Flush", "F" },
            { "Straight", "S" },
            { "Trips", "T" },
            { "Two Pair", "W" },
            { "Pair", "P" }
        };

        public Data() {

        }

        public static int getDrawRanking(string key) {
            return Data.drawRankings[key];
        }

        public static string getInitial(string key) {
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
