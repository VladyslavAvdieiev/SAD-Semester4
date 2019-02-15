using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IDevice {
        string Title { get; }
        bool InProgress { get; }
        bool HasElectricityConnection { get; set; }
        bool HasNetworkConnection { get; set; }
    }
}
