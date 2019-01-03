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

        public GameWindow() {
            InitializeComponent();

            this.DataContext = new GameVM();

            //GameVM vm = (GameVM)this.DataContext;

            //tb2.Text = vm.game.ante.ToString();

            /*
            * tableView.Navigate(new TableView(vm.game.table));
            * infoView.Navigate(new InfoView());
            * actionView.Navigate(new ActionView(vm.game));
            */
        }


        private void betSizeInput_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) {
                e.Handled = true;
            }
        }

    }
}
