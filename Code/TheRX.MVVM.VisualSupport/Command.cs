using System;
using System.Windows.Input;

namespace TheRX.MVVM.VisualSupport
{
    public abstract class Command : ICommand
    {
        private bool _canExecute;

        protected Command(bool canExecute = true)
        {
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public abstract void Execute(object parameter);

        protected void SetCanExecute(bool canExecute)
        {
            _canExecute = canExecute;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}