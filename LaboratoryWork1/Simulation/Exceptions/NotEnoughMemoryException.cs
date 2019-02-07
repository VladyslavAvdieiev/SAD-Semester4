using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Exceptions
{
    public class NotEnoughMemoryException : Exception {
        public NotEnoughMemoryException() : base() { }
        public NotEnoughMemoryException(string message) : base(message) { }
        public NotEnoughMemoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
