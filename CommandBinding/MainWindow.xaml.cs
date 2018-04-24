// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180424 10:25
// Description:   

#region

using System.Windows;
using System.Windows.Input;

#endregion

namespace CommandBinding {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
        }

        private void cb_Executed(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show(e.Parameter.ToString());
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (ChkCommand?.IsChecked != null) {
                e.CanExecute = ChkCommand.IsChecked.Value;
            }
        }

        private void cb_Executed2(object sender, ExecutedRoutedEventArgs e) {
            MessageBox.Show(e.Parameter.ToString());
        }

        private void CommandBinding_CanExecute2(object sender, CanExecuteRoutedEventArgs e) {
            if (ChkCommand?.IsChecked != null) {
                e.CanExecute = !ChkCommand.IsChecked.Value;
            }
        }

        RelayCommand _saveCommand;
        DelegateCommand _saveCommand2;

        public ICommand SaveCommand {
            get {
                return _saveCommand ?? (_saveCommand = new RelayCommand(param => Save(), CanSave));
            }
        }

        public ICommand SaveCommand2 {
            get {
                return _saveCommand2 ?? (_saveCommand2 = new DelegateCommand(param => Save2(), CanSave2));
            }
        }

        void Save() {
            MessageBox.Show("afasdfasdfasdf");
        }

        private bool CanSave(object param) {
            return true;
        }


        void Save2() {
            MessageBox.Show("ewrqwerqwer");
        }

        private bool CanSave2(object param) {
            return true;
        }
    }

}