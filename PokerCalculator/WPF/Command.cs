using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    public class Command : ICommand {

        Action<object> executeMethod;
        Func<object, bool> canExecuteMethod;

        // used to update CanExecute if the UI is changed 
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // constructor
        public Command(Action<object> executeMethod, Func<object, bool> canExecuteMethod) {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        // used to manually raise CanExecute
        public void RaiseCanExecuteChanged() {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object e) {
            bool outcome = this.canExecuteMethod(e);
            return outcome;
        }

        public void Execute(object e) {
            this.executeMethod(e);
        }
    }
}
