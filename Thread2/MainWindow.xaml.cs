// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180505 10:40
// Description:   

#region

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

#endregion

namespace Thread2 {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            placeHolder.Source = new Uri("http://www.msn.com");
        }

        private void Browse(object sender, RoutedEventArgs e) {
            placeHolder.Source = new Uri(newLocation.Text);
        }

        private void NewWindowHandler(object sender, RoutedEventArgs e) {
            Thread newWindowThread = new Thread(ThreadStartingPoint);
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void ThreadStartingPoint() {
            MainWindow tempWindow = new MainWindow();
            tempWindow.Show();
            Dispatcher.Run();
        }

    }

}