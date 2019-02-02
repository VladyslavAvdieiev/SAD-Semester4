using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class DeviceEventArgs : EventArgs {
        public string Message { get; }
        public DeviceEventArgs(string message) {
            Message = message;
        }
    }
}
