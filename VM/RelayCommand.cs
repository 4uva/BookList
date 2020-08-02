using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace BookList.VM
{
    class RelayCommand : ICommand
    {
        protected readonly Func<bool> canExecute;
        protected readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public RelayCommand(Action execute) : this(execute, () => true) { }

        public bool CanExecute(object parameter) => canExecute();
        public void Execute(object parameter) => execute();
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
