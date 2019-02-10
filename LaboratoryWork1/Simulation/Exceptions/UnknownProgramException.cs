using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class UnknownProgramException : Exception {
        public UnknownProgramException() : base() { }
        public UnknownProgramException(string message) : base(message) { }
        public UnknownProgramException(string message, Exception innerException) : base(message, innerException) { }
    }
}
