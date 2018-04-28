// FileName:  RelayCommand.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180424 11:06
// Description:   

#region

using System;
using System.Windows.Input;

#endregion

namespace CommandBinding {

    public class RelayCommand : ICommand {

        #region Constructors 

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null) {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter) {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter) {
            _execute(parameter);
        }

        #endregion

    }

}