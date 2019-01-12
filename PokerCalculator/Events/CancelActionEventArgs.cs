using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    public class CancelActionEventArgs : EventArgs
    {
        public Player player { get; set; }

        public CancelActionEventArgs(Player p) {
            this.player = p;
        }
    }
}
