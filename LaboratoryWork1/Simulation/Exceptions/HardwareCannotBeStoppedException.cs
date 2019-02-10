using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class HardwareCannotBeStoppedException : Exception {
        public HardwareCannotBeStoppedException() : base() { }
        public HardwareCannotBeStoppedException(string message) : base(message) { }
        public HardwareCannotBeStoppedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
