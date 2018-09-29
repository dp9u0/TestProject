// FileName:  DispatcherHangWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180601 15:14
// Description:   

#region

using System;
using System.Globalization;
using System.Threading;
using System.Windows;

#endregion

namespace WindbgSample {

    /// <summary>
    ///     DispatcherHangWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DispatcherHangWindow {

        public DispatcherHangWindow() {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            if (!long.TryParse(TextBox1.Text, out long inputNumber)) {
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
            Dispatcher.BeginInvoke((Action) delegate {
                TextBox2.Text = CalcSum((long) inputNumber).ToString(CultureInfo.InvariantCulture);
            });
        }

        private double CalcSum(long inputNumber) {
            double sum = 0;

            for (int i = 0; i < inputNumber; i++) {
                Thread.Sleep(10);
                sum += i;
            }

            return sum;
        }

    }

}