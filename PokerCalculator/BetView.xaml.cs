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
        public double betSize { get; }

        public BetView(Game g /*Player p, GameState gs, PotState ps*/) {
            InitializeComponent();

            //Console.WriteLine(this.DataContext.ToString());

            betSize = 0;

            betSizeInput.Text = betSize.ToString();
            betSizeSlider.Value = betSize;
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

        private void halfPotPreset_Click(object sender, RoutedEventArgs e) {
            //this.betSize = this.DataContext.player.stack
        }

        private void threeQuarterPotPreset_Click(object sender, RoutedEventArgs e) {

        }

        private void fullPotPreset_Click(object sender, RoutedEventArgs e) {

        }

        private void allInPreset_Click(object sender, RoutedEventArgs e) {

        }
    }
}
