using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PokerCalculator {
    public class GameVM : INotifyPropertyChanged {

        /* Logic */

        public Game game { get; }

        public Table table { get; }
        public List<Player> players { get; }

        public GameState gs { get; }
        public PotState ps { get; }

        public Player mainAccount { get; }
        public Player activePlayer { get; }
        public Pot pot { get; }
        public Board board { get; }

        /* UI */

        public double potSize { get; }


        /* Commands */

        public ICommand CallCommand { get; set; }
        public ICommand FoldCommand { get; set; }
        public ICommand RaiseCommand { get; set; }
        public ICommand UseTimeBankCommand { get; set; }

        public ICommand BetPreset1 { get; set; }
        public ICommand BetPreset2 { get; set; }
        public ICommand BetPreset3 { get; set; }
        public ICommand BetPreset4 { get; set; }


        /* Logic */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        public GameVM() {

            Player p1 = new Player("Nick", 2000);
            Player p2 = new Player("Matt", 2000);

            board = new Board(Data.ACE_OF_CLUBS.clone(), Data.ACE_OF_HEARTS.clone(), Data.EIGHT_OF_HEARTS.clone());

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
