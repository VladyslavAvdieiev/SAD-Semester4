using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public interface IProgram {
        string Title { get; }
        double PowerUsage { get; }
        bool NeedsNetwork { get; }
        double MemoryUsage { get; }
        bool Start();
        bool Stop();
    }
}
