using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class BatteryEventArgs : EventArgs {
        public string Message { get; }
        public double Capacity { get; }
        public double CurrentCharge { get; }
        public BatteryEventArgs(string message, double capacity, double currentCharge) {
            Message = message;
            Capacity = capacity;
            CurrentCharge = currentCharge;
        }
    }
}
