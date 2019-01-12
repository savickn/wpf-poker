using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    class AccountVM : INotifyPropertyChanged {

        /* Properties */

        private string name = "Dave";
        private double stack = 1000;

        public string Name {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        /* Commands */

        public ICommand CreateUser { get; set; }

        /* INotify Implementation */

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p) {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null) {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }

        public AccountVM() {
            this.CreateUser = new Command(this.createUser, this.canCreateUser);
        }

        /* Command Implementations */

        private bool canCreateUser(object e) {
            //if (Name == "Dave") return false;
            bool outcome = Name.Length > 0;
            Console.WriteLine(outcome);
            return outcome;
        }

        // create database entry
        private void createUser(object e) {
            using (var context = new AccountContext()) {
                var account = new Account(this.Name, this.stack);
                context.Accounts.Add(account);

                try {
                    context.SaveChanges();
                } catch (DbEntityValidationException ex) {
                    foreach (var errors in ex.EntityValidationErrors) {
                        foreach (var validationError in errors.ValidationErrors) {
                            // get the error message 
                            string errorMessage = validationError.ErrorMessage;
                            Console.WriteLine(errorMessage);
                        }
                    }
                }

                var accounts = context.Accounts.ToArray();
                Console.WriteLine($"We have {accounts.Length} accounts(s).");
                foreach (var acc in accounts) {
                    Console.WriteLine(acc);
                }
            }

        }



    }
}
