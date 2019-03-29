using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class BatteryRunOutException : Exception {
        public BatteryRunOutException() : base() { } 
        public BatteryRunOutException(string message) : base(message) { } 
        public BatteryRunOutException(string message, Exception innerException) : base(message, innerException) { }
    }
}
