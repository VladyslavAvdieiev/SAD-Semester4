using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class SoftwareCannotBeDisabledException : Exception {
        public SoftwareCannotBeDisabledException() : base() { }
        public SoftwareCannotBeDisabledException(string message) : base(message) { }
        public SoftwareCannotBeDisabledException(string message, Exception innerException) : base(message, innerException) { }
    }
}
