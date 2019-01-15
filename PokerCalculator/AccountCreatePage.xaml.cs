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

namespace PokerCalculator
{
    /// <summary>
    /// Interaction logic for AccountCreatePage.xaml
    /// </summary>
    public partial class AccountCreatePage : Page
    {
        public AccountCreatePage()
        {
            InitializeComponent();

            this.DataContext = new AccountVM();
        }
    }
}
