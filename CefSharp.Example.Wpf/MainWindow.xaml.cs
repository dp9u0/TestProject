// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 09:11
// Description:   

#region

using System.Runtime.InteropServices;
using System.Windows;

#endregion

namespace CefSharp.Example.Wpf {

    [ComVisible(true)]
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        private void btnWebBrowser_Click(object sender, RoutedEventArgs e) {
            new WebBrowserWindow().ShowDialog();
        }

        private void btnChromiumWebBrowser_Click(object sender, RoutedEventArgs e) {
            new ChromiumWebBrowserWindow().ShowDialog();
        }

    }

}