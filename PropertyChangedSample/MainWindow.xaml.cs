// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180521 11:04
// Description:   

#region

using System;
using System.Globalization;
using System.Windows;

#endregion

namespace PropertyChangedSample {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (DataContext is ViewModel vm)
                vm.TestText = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

    }

}