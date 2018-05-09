// FileName:  NetIncome.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:40
// Description:   

#region

using System.ComponentModel;

#endregion

namespace Binding {

    public class NetIncome : INotifyPropertyChanged {

        public NetIncome() {
            savings = totalIncome - (rent + food + misc);
        }

        private int totalIncome = 5000;
        private int rent = 2000;
        private int food;
        private int misc;
        private int savings;

        public int TotalIncome {
            get => totalIncome;
            set {
                if (TotalIncome != value) {
                    totalIncome = value;
                    OnPropertyChanged("TotalIncome");
                }
            }
        }

        public int Rent {
            get => rent;
            set {
                if (Rent != value) {
                    rent = value;
                    OnPropertyChanged("Rent");
                    UpdateSavings();
                }
            }
        }

        public int Food {
            get => food;
            set {
                if (Food != value) {
                    food = value;
                    OnPropertyChanged("Food");
                    UpdateSavings();
                }
            }
        }

        public int Misc {
            get => misc;
            set {
                if (Misc != value) {
                    misc = value;
                    OnPropertyChanged("Misc");
                    UpdateSavings();
                }
            }
        }

        public int Savings {
            get => savings;
            set {
                if (Savings != value) {
                    savings = value;
                    OnPropertyChanged("Savings");
                    UpdateSavings();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateSavings() {
            Savings = TotalIncome - (Rent + Misc + Food);
            if (Savings < 0) {
            } else if (Savings >= 0) {
            }
        }

        private void OnPropertyChanged(string info) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }

}