using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class DeviceEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public bool IsEnabled { get; }
        public bool HasElectricityConnection { get; }
        public bool HasNetworkConnection { get; }
        public DeviceEventArgs(string message, string title, bool isEnabled, bool hasElectricityConnection, bool hasNetworkConnection) {
            Message = message;
            Title = title;
            IsEnabled = isEnabled;
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }
    }
}
