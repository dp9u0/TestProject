// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180505 09:59
// Description:   

#region

using System;
using System.Windows;
using System.Windows.Threading;

#endregion

namespace Thread {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        //Current number to check 
        private long _num = 3;

        private bool _continueCalculating;

        private bool _notAPrime;


        private void StartOrStop(object sender, EventArgs e) {
            if (_continueCalculating) {
                _continueCalculating = false;
                startStopButton.Content = "Resume";
            } else {
                _continueCalculating = true;
                startStopButton.Content = "Stop";
                startStopButton.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new NextPrimeDelegate(CheckNextNumber));
            }
        }

        public void CheckNextNumber() {
            // Reset flag.
            _notAPrime = false;

            for (long i = 3; i <= Math.Sqrt(_num); i++) {
                if (_num % i == 0) {
                    // Set not a prime flag to true.
                    _notAPrime = true;
                    break;
                }
            }

            // If a prime number.
            if (!_notAPrime) {
                bigPrime.Text = _num.ToString();
            }

            _num += 2;
            if (_continueCalculating) {
                startStopButton.Dispatcher.BeginInvoke(
                    DispatcherPriority.SystemIdle,
                    new NextPrimeDelegate(CheckNextNumber));
            }
        }

        public delegate void NextPrimeDelegate();

    }

}