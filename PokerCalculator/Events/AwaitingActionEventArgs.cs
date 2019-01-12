using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    public class AwaitingActionEventArgs
    {
        public Player player { get; set; }
        public GameState gameState { get; set; }
        public PotState potState { get; set; }

        public AwaitingActionEventArgs(GameState gs, PotState ps, Player p) {
            this.player = p;
            this.gameState = gs;
            this.potState = ps;
        }
    }
}
