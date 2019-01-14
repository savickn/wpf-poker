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
    /// Interaction logic for SeatView.xaml
    /// </summary>
    public partial class SeatView : Page {
        public Player player;

        public SeatView(Player p = null) {
            InitializeComponent();

            this.player = p;
            if(player != null) {
                playerName.Text = player.account.name;
                playerStack.Text = player.Stack.ToString();
            } else {
                playerName.Text = "Empty";
                playerStack.Text = "0";
            }

            //GameVM vm = (GameVM)this.DataContext;

            //p = vm.table.getSeatById(1).player;

            //playerName.Text = p.name;
        }
    }
}
