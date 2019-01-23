using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    public enum PlayerStatus {
        ACTIVE, // AKA in the game, should be dealt hands
        SITTING_OUT, // opposite of ACTIVE
        FOLDED, // player can no longer BET/CHECK
        ALL_IN, // still In_Hand but cannot BET/CHECK
        IN_HAND // can make actions
    }
}
