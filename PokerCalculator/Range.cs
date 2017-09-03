using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Range<T> where T : PreflopHand {
        public List<T> hands { get; private set; }
        public int length { get; private set; }

        public Range(List<T> hands) {
            this.hands = hands;
            this.length = hands.Count;
        }

        public void addHandsToRange(List<T> hands) {
            this.hands = this.hands.Concat(hands).ToList();
        }

        public void removeHandsToRange(List<T> hands) {
            foreach(T h in hands) {
                this.hands.Remove(h);
            }
        }
    }
}
