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
    /// Interaction logic for BetView.xaml
    /// </summary>
    public partial class BetView : Page {
        public BetView(/*Player p, GameState gs, PotState ps*/) {
            InitializeComponent();

            //double betSize = 0;


        }


        private void foldBtn_Click(object sender, RoutedEventArgs e) {
            //double betSize = (double)betSizeInput.Text;


        }

        private void callBtn_Click(object sender, RoutedEventArgs e) {
            //double betSize = (double)betSizeInput.Text;


        }

        private void raiseBtn_Click(object sender, RoutedEventArgs e) {

        }

        private void betSizeInput_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) {
                e.Handled = true;
            }
        }
    }
}
