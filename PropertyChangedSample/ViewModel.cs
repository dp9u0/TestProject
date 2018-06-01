// FileName:  ViewModel.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180521 11:04
// Description:   

#region

using System.ComponentModel;
using PropertyChangedSample.Annotations;

#endregion

namespace PropertyChangedSample {

    public class ViewModel : INotifyPropertyChanged {

        private string testText;

        public string TestText {
            get {
                return testText;
            }
            set {
                testText = value;
                OnPropertyChanged("");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}