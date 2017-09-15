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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerCalculator {
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page {
        public Home() {
            InitializeComponent();

            Player p1 = new Player("Nick", 2000);
            Player p2 = new Player("Matt", 2000);

            Game g = new Game(GameTypes.nl2k);
            g.registerPlayer(p1);
            g.registerPlayer(p2);

            g.initializeGame();
            g.run();

        }

        // text entry of bet size
        public void selectAmount() {

        }

        // for bet/raise button
        public void BetRaise() {

        }

        // for call button
        public void Call() {

        }

        // for fold button
        public void Fold() {

        }
    }
}
