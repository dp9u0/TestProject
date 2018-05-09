// FileName:  WhenUpdatesWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:52
// Description:   

#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#endregion

namespace Binding {

    /// <summary>
    ///     WhenUpdatesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WhenUpdatesWindow : Window {

        public WhenUpdatesWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            BindingExpression be = ItemNameTextBox.GetBindingExpression(TextBox.TextProperty);
            be?.UpdateSource();
        }

    }

}