using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace PokerCalculator {
    public class GameVM {
        public Game game { get; }
        public Table table { get; }
        public List<Player> players { get; }

        public GameState gs { get; }
        public PotState ps { get; }

        public Player mainAccount { get; }
        public Player activePlayer { get; }
        public Pot pot { get; }
        public Board board { get; }

        public GameVM() {

            Player p1 = new Player("Nick", 2000);
            Player p2 = new Player("Matt", 2000);

            mainAccount = p1;

            table = new Table(GameTypes.nl2k.numberOfSeats);

            game = new Game(table, GameTypes.nl2k);
            game.registerPlayer(p1);
            game.registerPlayer(p2);

            game.initializeGame();
            //game.run();
        }

    }
}
