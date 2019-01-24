using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    // used to update Player after their turn (both for Fold and Call/Raise/etc)
    // close UI, update CurrentContribution
    // called ONLY in 'DecrementTimer' (if time runs out) or in 'ReceivePlayerAction' (if response is received)
    public class CancelActionEventArgs : EventArgs {
        public Player player { get; set; } // identifies the correct Player to update
        public double contribution { get; set; } // updated pot contribution

        public CancelActionEventArgs(Player p, double contribution) {
            this.player = p;
            this.contribution = contribution;
        }
    }
}
