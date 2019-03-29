using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class UnknownSoftwareException : Exception {
        public UnknownSoftwareException() : base() { }
        public UnknownSoftwareException(string message) : base(message) { }
        public UnknownSoftwareException(string message, Exception innerException) : base(message, innerException) { }
    }
}
