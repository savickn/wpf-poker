using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    // used to update Player before their turn (ONLY called in 'bettingRound')
    // render UI, update MinRaise/ToCall/etc
    public class AwaitingActionEventArgs
    {
        public Player player { get; set; } // identifies the correct Player to update
        public GameState gameState { get; set; } // updated GameState
        public PotState potState { get; set; } // updated PotState

        public AwaitingActionEventArgs(GameState gs, PotState ps, Player p) {
            this.player = p;
            this.gameState = gs;
            this.potState = ps;
        }
    }
}
