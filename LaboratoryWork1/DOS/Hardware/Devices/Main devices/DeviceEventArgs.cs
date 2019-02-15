using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class DeviceEventArgs : EventArgs {
        public string Message { get; }
        public bool InProgress { get; }
        public bool HasElectricityConnection { get; }
        public bool HasNetworkConnection { get; }
        public DeviceEventArgs(string message, bool inProgress, bool hasElectricityConnection, bool hasNetworkConnection) {
            Message = message;
            InProgress = inProgress;
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }
    }
}
