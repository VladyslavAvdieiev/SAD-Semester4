using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class UnknownHardwareException : Exception {
        public UnknownHardwareException() : base() { }
        public UnknownHardwareException(string message) : base(message) { }
        public UnknownHardwareException(string message, Exception innerException) : base(message, innerException) { }
    }
}
