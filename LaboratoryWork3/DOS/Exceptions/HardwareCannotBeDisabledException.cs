using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class HardwareCannotBeDisabledException : Exception {
        public HardwareCannotBeDisabledException() : base() { }
        public HardwareCannotBeDisabledException(string message) : base(message) { }
        public HardwareCannotBeDisabledException(string message, Exception innerException) : base(message, innerException) { }
    }
}
