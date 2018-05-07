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
using System.Windows.Shapes;

namespace ControlSimple {
    /// <summary>
    /// ButtonWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonWindow : Window {
        public ButtonWindow() {
            InitializeComponent();
        }
        void OnClick5(object sender, RoutedEventArgs e) {
            btn6.FontSize = 16;
            btn6.Content = "This is my favorite photo.";
            btn6.Background = Brushes.Red;
        }

    }
}
