using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class SoftwareCannotBeEnabledException : Exception {
        public SoftwareCannotBeEnabledException() : base() { }
        public SoftwareCannotBeEnabledException(string message) : base(message) { }
        public SoftwareCannotBeEnabledException(string message, Exception innerException) : base(message, innerException) { }
    }
}
