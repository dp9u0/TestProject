using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace xStatic {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }


        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();


        private void ExecutedCustomCommand(object sender,
            ExecutedRoutedEventArgs e) {
            MessageBox.Show("Custom Command Executed");
        }

        // CanExecuteRoutedEventHandler that only returns true if
        // the source is a control.
        private void CanExecuteCustomCommand(object sender,
            CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }

        public static RoutedCommand CustomRoutedCommand2 = new RoutedCommand();

        private void ExecutedCustomCommand2(object sender,
            ExecutedRoutedEventArgs e) {
            MessageBox.Show("Custom Command2 Executed");
        }

        // CanExecuteRoutedEventHandler that only returns true if
        // the source is a control.
        private void CanExecuteCustomCommand2(object sender,
            CanExecuteRoutedEventArgs e) {
            Control target = e.Source as Control;

            if (target != null) {
                e.CanExecute = true;
            } else {
                e.CanExecute = false;
            }
        }
    }
}
