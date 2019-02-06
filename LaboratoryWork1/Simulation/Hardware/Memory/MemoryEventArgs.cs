using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class MemoryEventArgs : EventArgs {
        public string Message { get; }
        public double Capacity { get; }
        public double UsedSpace { get; }
        public MemoryEventArgs(string message, double capacity, double usedSpace) {
            Message = message;
            Capacity = capacity;
            UsedSpace = usedSpace;
        }
    }
}
