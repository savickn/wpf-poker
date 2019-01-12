using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    public class ReceivedActionEventArgs : EventArgs
    {
        public Action action { get; set; }

        public ReceivedActionEventArgs(Action a) {
            this.action = a;
        }

    }
}
