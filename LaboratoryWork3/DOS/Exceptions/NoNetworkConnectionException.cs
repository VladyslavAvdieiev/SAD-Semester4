using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class NoNetworkConnectionException : Exception {
        public NoNetworkConnectionException() : base() { }
        public NoNetworkConnectionException(string message) : base(message) { }
        public NoNetworkConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
