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
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class TableView : Page {
        public Table table { get; }

        public TableView(Table t) {
            InitializeComponent();

            this.table = t;

            Seat1.Navigate(new SeatView(t.getSeatById(1).player));
            Seat2.Navigate(new SeatView(t.getSeatById(2).player));
            Seat3.Navigate(new SeatView(t.getSeatById(3).player));
            Seat4.Navigate(new SeatView(t.getSeatById(4).player));
            Seat5.Navigate(new SeatView(t.getSeatById(5).player));
            Seat6.Navigate(new SeatView(t.getSeatById(6).player));
            Seat7.Navigate(new SeatView(t.getSeatById(7).player));
            Seat8.Navigate(new SeatView(t.getSeatById(8).player));
            Seat9.Navigate(new SeatView(t.getSeatById(9).player));
            //Seat10.Navigate(new SeatView(t.getSeatById(10).player));

        }
    }
}
