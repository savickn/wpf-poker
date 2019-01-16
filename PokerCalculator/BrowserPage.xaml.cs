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

namespace PokerCalculator
{
    /// <summary>
    /// Interaction logic for BrowserWindow.xaml
    /// </summary>
    public partial class BrowserPage : Page
    {
        public BrowserPage()
        {
            InitializeComponent();

            this.DataContext = new BrowserVM();
        }

        private void Create_Game(object sender, RoutedEventArgs e) {
            CreateGameWindow cgw = new CreateGameWindow();
            cgw.Show();
        }
    }
}
