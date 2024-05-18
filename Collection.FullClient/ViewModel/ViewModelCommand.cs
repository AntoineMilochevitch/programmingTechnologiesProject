using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Collection.FullClient.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Fields
        private Action<Object> _executeAction;
        private Predicate<object> _canExcecuteAction;

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExcecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExcecuteAction)
        {
            _executeAction = executeAction;
            _canExcecuteAction = canExcecuteAction;
        }


        //Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            return _canExcecuteAction == null ? true : _canExcecuteAction(parameter);
            
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
