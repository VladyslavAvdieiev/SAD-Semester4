using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class BatteryEventArgs : EventArgs {
        public string Message { get; }
        public BatteryEventArgs(string message) {
            Message = message;
        }
    }
}
