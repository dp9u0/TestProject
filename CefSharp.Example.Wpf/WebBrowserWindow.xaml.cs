// FileName:  WebBrowserWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 09:31
// Description:   

#region

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Navigation;
using mshtml;

#endregion

namespace CefSharp.Example.Wpf {

    [ComVisible(true)]
    public partial class WebBrowserWindow {

        public WebBrowserWindow() {
            InitializeComponent();
            var url = new Uri("file://" + Path.Combine(Environment.CurrentDirectory, "index.html"));
            Browser.Navigate(url);
            TxtBoxAddress.Text = url.AbsoluteUri;
            Browser.Navigated += Browser_Navigated;
        }

        private void Browser_Navigated(object sender, NavigationEventArgs e) {
            try {
                Browser.ObjectForScripting = new BoundObject(); //指定脚本消息送到当前实例处理
            } catch (Exception) {
                //throw;
            }
        }

        private void BtnGoClick(object sender, RoutedEventArgs e) {
            Browser.Source = new Uri(TxtBoxAddress.Text);
        }

        private void Tests1_Click(object sender, RoutedEventArgs e) {
            if (Browser.Document is HTMLDocument dom) {
                var txtBox = dom.getElementById("txtBox");
                txtBox.setAttribute("value", DateTime.Now.Ticks);
            }
        }

        private void Tests2_Click(object sender, RoutedEventArgs e) {
            if (Browser.Document is HTMLDocument dom) {
                var btnOk = dom.getElementById("btnOk");
                btnOk.click();
            }
        }


        private void MenuItem_OnClick(object sender, RoutedEventArgs e) {
            Browser.InvokeScript("alerttest", "world");
        }

    }

}