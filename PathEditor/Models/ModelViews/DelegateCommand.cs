using System;
using System.Windows.Input;
using SunamoExceptions;

namespace PathEditor.ModelViews
{
    public class DelegateCommand : ICommand
    {
        static Type type = typeof(DelegateCommand);
        private static readonly Predicate<object> DefaultCanExecute = ((arg) => true);

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action<object> onExecuteMethod, Predicate<object> onCanExecuteMethod = null)
        {
            if (onExecuteMethod == null) ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),"onExecuteMethod");

            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod ?? DefaultCanExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}