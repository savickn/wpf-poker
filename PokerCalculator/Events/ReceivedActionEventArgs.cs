using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    // used to pass Player Action to the main game 
    public class ReceivedActionEventArgs : EventArgs
    {
        public Action action { get; set; }

        public ReceivedActionEventArgs(Action a) {
            this.action = a;
        }
    }
}
