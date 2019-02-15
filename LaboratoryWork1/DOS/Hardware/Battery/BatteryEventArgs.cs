using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class BatteryEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public double Capacity { get; }
        public double CurrentCharge { get; }
        public BatteryEventArgs(string message, string title, double capacity, double currentCharge) {
            Message = message;
            Title = title;
            Capacity = capacity;
            CurrentCharge = currentCharge;
        }
    }
}
