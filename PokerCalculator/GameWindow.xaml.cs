using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokerCalculator {
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    /// 
    public partial class GameWindow : Window {

        public Game game { get; }

        public GameWindow() {
            InitializeComponent();

            Player p1 = new Player("Nick", 2000);
            Player p2 = new Player("Matt", 2000);

            game = new Game(GameTypes.nl2k);
            game.registerPlayer(p1);
            game.registerPlayer(p2);

            game.initializeGame();
            //game.run();
        }
    }
}
