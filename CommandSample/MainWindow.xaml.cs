// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180503 10:50
// Description:   

#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#endregion

namespace CommandSample {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void OpenCmdExecuted(object target, ExecutedRoutedEventArgs e) {
            string command = ((RoutedCommand) e.Command).Name;
            string targetobj = ((FrameworkElement) target).Name;
            MessageBox.Show("The " + command + " command has been invoked on target object " + targetobj);
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void Bttn1_OnClick(object sender, RoutedEventArgs e) {
            (e.Source as Button).Visibility = Visibility.Hidden;
        }

    }

}