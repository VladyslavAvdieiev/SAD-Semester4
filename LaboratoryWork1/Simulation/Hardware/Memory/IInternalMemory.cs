using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IInternalMemory : IMemory {
        string Title { get; }
        double Capacity { get; }
        double FreeSpace { get; }
        double UsedSpace { get; set; }
        bool Format();
    }
}
