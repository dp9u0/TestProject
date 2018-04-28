// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 15:05
// Description:   

#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

#endregion

namespace WpfApp {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            var strList = new List<string>();

            strList.Add("adfadfsasfd");
            strList.Add("adfadfsasfd");

            strList.Add("adfadfsasfd");
            strList.Add("adfadfsasfd");
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Button
        }

    }

}