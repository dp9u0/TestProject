// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180504 09:49
// Description:   

#region

using System.Windows;
using System.Windows.Media;

#endregion

namespace Resources {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Resources["MyBrush"] = Brushes.Aqua;
        }

    }

}