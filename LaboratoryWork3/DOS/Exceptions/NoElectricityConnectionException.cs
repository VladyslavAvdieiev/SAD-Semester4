using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class NoElectricityConnectionException : Exception {
        public NoElectricityConnectionException() : base() { }
        public NoElectricityConnectionException(string message) : base(message) { }
        public NoElectricityConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
