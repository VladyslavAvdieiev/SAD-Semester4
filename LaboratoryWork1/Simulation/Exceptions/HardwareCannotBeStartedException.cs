using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class HardwareCannotBeStartedException : Exception {
        public HardwareCannotBeStartedException() : base() { }
        public HardwareCannotBeStartedException(string message) : base(message) { }
        public HardwareCannotBeStartedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
