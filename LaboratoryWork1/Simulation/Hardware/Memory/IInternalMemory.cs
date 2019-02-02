using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IInternalMemory : IMemory {
        #pragma warning disable CS0108
        string Title { get; }
        double Capacity { get; }
        double FreeSpace { get; }
        double UsedSpace { get; set; }
        bool Format();
        #pragma warning restore CS0108
    }
}
