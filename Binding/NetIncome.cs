﻿// FileName:  NetIncome.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:40
// Description:   

using System;
using System.ComponentModel;

namespace Binding {

    public class NetIncome : INotifyPropertyChanged {
        private int totalIncome = 5000;
        private int rent = 2000;
        private int food = 0;
        private int misc = 0;
        private int savings = 0;
        public NetIncome() {
            savings = totalIncome - (rent + food + misc);
        }

        public int TotalIncome {
            get {
                return totalIncome;
            }
            set {
                if (TotalIncome != value) {
                    totalIncome = value;
                    OnPropertyChanged("TotalIncome");
                }
            }
        }
        public int Rent {
            get {
                return rent;
            }
            set {
                if (Rent != value) {
                    rent = value;
                    OnPropertyChanged("Rent");
                    UpdateSavings();
                }
            }
        }
        public int Food {
            get {
                return food;
            }
            set {
                if (Food != value) {
                    food = value;
                    OnPropertyChanged("Food");
                    UpdateSavings();
                }
            }
        }
        public int Misc {
            get {
                return misc;
            }
            set {
                if (Misc != value) {
                    misc = value;
                    OnPropertyChanged("Misc");
                    UpdateSavings();
                }
            }
        }
        public int Savings {
            get {
                return savings;
            }
            set {
                if (Savings != value) {
                    savings = value;
                    OnPropertyChanged("Savings");
                    UpdateSavings();
                }
            }
        }

        private void UpdateSavings() {
            Savings = TotalIncome - (Rent + Misc + Food);
            if (Savings < 0) { } else if (Savings >= 0) { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }

}