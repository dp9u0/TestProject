// FileName:  WeatherComponent2.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180505 10:58
// Description:   

#region

using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

#endregion

namespace Thread {

    public class WeatherComponent2 : Component {

        private DispatcherSynchronizationContext _requestingContext;

        public string GetWeather() {
            return FetchWeatherFromServer();
        }

        public void GetWeatherAsync() {
            if (_requestingContext != null)
                throw new InvalidOperationException("This component can only handle 1 async request at a time");

            _requestingContext = (DispatcherSynchronizationContext) SynchronizationContext.Current;

            NoArgDelegate fetcher = FetchWeatherFromServer;

            // Launch thread
            fetcher.BeginInvoke(null, null);
        }

        private void RaiseEvent(EventArgs e) {
            GetWeatherCompleted?.Invoke(this, e);
        }

        private string FetchWeatherFromServer() {
            // do stuff
            SendOrPostCallback callback = DoEvent;
            _requestingContext.Post(callback, "");
            _requestingContext = null;
            return "";
        }

        private void DoEvent(object e) {
            //do stuff
        }

        public event EventHandler GetWeatherCompleted;

        public delegate string NoArgDelegate();

    }

}