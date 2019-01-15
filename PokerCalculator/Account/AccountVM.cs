using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    class AccountVM : INotifyPropertyChanged {

        /* Properties */

        private List<Account> accounts;
        private string name;
        private double stack;

        public string Name {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public List<Account> Accounts {
            get { return this.accounts; }
            set { this.accounts = value; OnPropertyChanged("Accounts"); }
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
            this.stack = 1000;
            this.CreateUser = new Command(this.createUser, this.canCreateUser);

            this.getUsers();
        }

        // retrieve existing Accounts from db
        private void getUsers() {
            using (var context = new AccountContext()) {
                Accounts = context.accounts.ToList();
            }
        }

        /* Command Implementations */

        private bool canCreateUser(object e) {
            if (Name == null) return false;
            return Name.Length > 0;
        }

        // create database entry
        private void createUser(object e) {
            using (var context = new AccountContext()) {
                var account = new Account(this.Name, this.stack);
                context.accounts.Add(account);

                try {
                    context.SaveChanges();
                } catch (DbEntityValidationException ex) {
                    foreach (var errors in ex.EntityValidationErrors) {
                        foreach (var validationError in errors.ValidationErrors) {
                            string errorMessage = validationError.ErrorMessage;
                            Debug.WriteLine(errorMessage);
                        }
                    }
                }
                // refresh list of Accounts from db
                this.getUsers();
            }
        }
    }
}
