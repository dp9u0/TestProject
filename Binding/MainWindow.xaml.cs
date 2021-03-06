﻿// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:39
// Description:   

#region

using System.Windows;

#endregion

namespace Binding {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            new SimpleBindingWindow().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            new BindingSourceWindow().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            new WhenUpdatesWindow().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            new BindingModeWindow().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            new BindCollectionWindow().ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {
            new BindEnumerationWindow().ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) {
            new BindControlWindow().ShowDialog();
        }
    }

}