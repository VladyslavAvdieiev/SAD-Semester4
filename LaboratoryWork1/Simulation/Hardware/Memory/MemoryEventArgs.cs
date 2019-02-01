using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class MemoryEventArgs : EventArgs {
        public string Message { get; }
        public MemoryEventArgs(string message) {
            Message = message;
        }
    }
}
