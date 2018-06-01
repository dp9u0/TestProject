using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace DispatcherHang {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (!Int64.TryParse(textBox1.Text, out long inputNumber)) {
                MessageBox.Show("请输入1亿-10亿皑间的整型数据！");
                return;
            }
            if (inputNumber > 2500000000 || inputNumber < 100000000) {
                MessageBox.Show("请输入1亿-10亿间的整型数据！");
                return;
            }
            Thread newThread = new Thread(GetResult);
            newThread.Start(inputNumber);
        }

        private void GetResult(object inputNumber) {
            Dispatcher.BeginInvoke((Action)delegate () {
                textBox2.Text = CalcSum((Int64)inputNumber).ToString(CultureInfo.InvariantCulture);
            });
        }

        private double CalcSum(Int64 inputNumber) {
            double sum = 0;
           
            for (int i = 0; i < inputNumber; i++) {
                Thread.Sleep(10);
                sum += i;
            }
            return sum;
        }
    }
}