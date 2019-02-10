using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class SoftwareCannotBeStartedException : Exception {
        public SoftwareCannotBeStartedException() : base() { }
        public SoftwareCannotBeStartedException(string message) : base(message) { }
        public SoftwareCannotBeStartedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
