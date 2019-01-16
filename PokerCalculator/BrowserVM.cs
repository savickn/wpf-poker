using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator
{
    public class BrowserVM : INotifyPropertyChanged
    {
        private List<Game> games;
        public List<Game> Games {
            get { return this.games; }
            set { games = value; OnPropertyChanged("Games"); }
        }

        /* Commands */

        public ICommand OpenGame { get; set; }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        /* Class Logic */

        public BrowserVM() {
            this.OpenGame = new Command(this.openGame, this.canOpenGame);
            this.getGames();
        }

        // retrieves list of games from db
        private void getGames() {
            using (var context = new GameContext()) {
                Games = context.games.ToList();
            }
        }

        // used to check if game can be opened
        private bool canOpenGame(object e) {
            return true;
        }

        // used to open game in separate Window
        private void openGame(object e) {
            PokerWindow pw = new PokerWindow((Game)e);
            pw.Show();
        }
    }
}
