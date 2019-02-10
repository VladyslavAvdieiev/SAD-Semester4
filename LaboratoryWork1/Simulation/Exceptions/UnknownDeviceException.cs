using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class UnknownDeviceException : Exception {
        public UnknownDeviceException() : base() { }
        public UnknownDeviceException(string message) : base(message) { }
        public UnknownDeviceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
