using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class DriveIsEmptyException : Exception {
        public DriveIsEmptyException() : base() { }
        public DriveIsEmptyException(string message) : base(message) { }
        public DriveIsEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
