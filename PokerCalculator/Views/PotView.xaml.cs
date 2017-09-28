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
    /// Interaction logic for PotView.xaml
    /// </summary>
    public partial class PotView : Page {

        public string potSize;
        public string PotSize {
            get { return potSize; }
            set { potSize = value; }
        }

        public PotView() {
            PotSize = "10";
            InitializeComponent();
        }

        private void incrementPot_Click(object sender, RoutedEventArgs e) {
            PotSize += 5;
            e.Handled = true;
        }
    }
}
