// FileName:  Person.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:44
// Description:   

#region

using System.ComponentModel;

#endregion

namespace Binding {

    public class Person : INotifyPropertyChanged {

        private string _personName;

        public string PersonName {
            get => _personName;
            set {
                if (string.Equals(value, PersonName))
                    return;
                _personName = value;
                OnPropertyChanged("PersonName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

    }

}