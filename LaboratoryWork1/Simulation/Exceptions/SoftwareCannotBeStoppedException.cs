using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class SoftwareCannotBeStoppedException : Exception {
        public SoftwareCannotBeStoppedException() : base() { }
        public SoftwareCannotBeStoppedException(string message) : base(message) { }
        public SoftwareCannotBeStoppedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
