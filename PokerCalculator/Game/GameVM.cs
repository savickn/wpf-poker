using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator
{
    public class GameVM : INotifyPropertyChanged
    {
        /* Properties */

        private int numberOfSeats;
        private int cardsPerHand;
        private double bigBlind;

        public int NumberOfSeats {
            get { return numberOfSeats; }
            set { numberOfSeats = value; OnPropertyChanged("NumberOfSeats"); }
        }

        public int CardsPerHand {
            get { return cardsPerHand; }
            set { cardsPerHand = value; OnPropertyChanged("CardsPerHand"); }
        }

        public double BigBlind {
            get { return bigBlind; }
            set { bigBlind = value; OnPropertyChanged("BigBlind"); }
        }

        /* Commands */

        public ICommand CreateGame { get; set; }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        public GameVM() {
            this.NumberOfSeats = 2;
            this.CardsPerHand = 2;
            this.BigBlind = 2;
            this.CreateGame = new Command(this.createGame, this.canCreateGame);
        }

        /* Command Implementations */

        // recheck
        private bool canCreateGame(object e) {
            if (NumberOfSeats == null || CardsPerHand == null || BigBlind == null) return false;
            if (NumberOfSeats < 2 || NumberOfSeats > 10) return false;
            return true;
        }

        // create database entry
        private void createGame(object e) {
            using (var context = new GameContext()) {
                var game = new Game(this.NumberOfSeats, this.CardsPerHand, this.BigBlind);
                context.games.Add(game);
                context.SaveChanges();
            }
        }

    }
}
