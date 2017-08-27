using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    enum PlayerStatus {
        ACTIVE, // AKA in the game, should be dealt hands
        SITTING_OUT, 
        FOLDED, // player can no longer BET/CHECK
        ALL_IN,
        IN_HAND
    }
}
