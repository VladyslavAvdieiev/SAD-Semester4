using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IExternalStorage : IMemory {
        string Title { get; }
        double Capacity { get; }
        double FreeSpace { get; set; }
        bool Format();
    }
}
