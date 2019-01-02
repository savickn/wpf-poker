using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerCalculator {
    class Command : ICommand {

        Action<object> executeMethod;
        Func<object, bool> canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        // alternative implementation
        /*public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }*/

        public Command(Action<object> executeMethod, Func<object, bool> canExecuteMethod) {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
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
