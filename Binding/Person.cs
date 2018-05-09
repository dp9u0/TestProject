// FileName:  Person.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180509 13:44
// Description:   

#region

using System.ComponentModel;

#endregion

namespace Binding {

    public class Person : INotifyPropertyChanged {

        public Person(string s) {
            _personName = s;
        }

        public Person() : this(string.Empty) {
        }

        private string _personName;

        public string PersonName {
            get => _personName;
            set {
                if (string.Equals(value, _personName))
                    return;
                _personName = value;
                OnPropertyChanged("PersonName");
            }
        }

        public string Name {
            get => _personName;
            set {
                if (string.Equals(value, _personName))
                    return;
                _personName = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }

}