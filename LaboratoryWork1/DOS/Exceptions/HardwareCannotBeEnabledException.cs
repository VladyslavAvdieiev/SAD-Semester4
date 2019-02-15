using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class HardwareCannotBeEnabledException : Exception {
        public HardwareCannotBeEnabledException() : base() { }
        public HardwareCannotBeEnabledException(string message) : base(message) { }
        public HardwareCannotBeEnabledException(string message, Exception innerException) : base(message, innerException) { }
    }
}
