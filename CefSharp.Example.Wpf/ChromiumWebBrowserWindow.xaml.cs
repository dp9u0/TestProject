// FileName:  ChromiumWebBrowserWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 09:30
// Description:   

#region

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

#endregion

namespace CefSharp.Example.Wpf {

    /// <summary>
    ///     ChromiumWebBrowserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChromiumWebBrowserWindow : Window {

        private static readonly BoundObject _boundObject = new BoundObject();

        public ChromiumWebBrowserWindow() {
            InitializeComponent();
            Browser.RegisterJsObject("external", _boundObject);
            Browser.Address = "file://" + Path.Combine(Environment.CurrentDirectory, "index.html");
        }

        private void btnGoClick(object sender, RoutedEventArgs e) {
            Browser.Load(txtBoxAddress.Text);
        }

        private void Tests1_Click(object sender, RoutedEventArgs e) {
            Browser.GetBrowser().MainFrame
                .ExecuteJavaScriptAsync("document.getElementById('txtBox').value='set from .net'");
        }

        private void Tests2_Click(object sender, RoutedEventArgs e) {
            Browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("document.getElementById('btnOk').click();");
        }

    }

    [ComVisible(true)]
    public class BoundObject {

        public void myMethod() {
            MessageBox.Show("myMethod Called");
        }

        public void myMethod2() {
            MessageBox.Show("myMethod2 Called");
        }

        public void Log(string message) {
            // Log4net.log
        }

    }

}