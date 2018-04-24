// FileName:  DelegateCommand.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180424 11:17
// Description:   

#region

using System;
using System.Windows.Input;

#endregion

namespace CommandBinding {

    /// <summary>
    ///     Delegatecommand，这种WPF.SL都可以用，VIEW里面直接使用INTERACTION的trigger激发。比较靠谱，适合不同的UIElement控件
    /// </summary>
    public class DelegateCommand : ICommand {

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute) {
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _executeAction;
        private bool _canExecuteCache;

        #region ICommand Members

        public bool CanExecute(object parameter) {
            bool temp = _canExecute(parameter);
            if (_canExecuteCache != temp) {
                _canExecuteCache = temp;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
            return _canExecuteCache;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) {
            _executeAction(parameter);
        }

        #endregion

    }

}