using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public interface IProgram {
        string Title { get; }
        bool InProgress { get; }
        bool NeedsNetwork { get; }
        double PowerUsage { get; }
        double MemoryUsage { get; }
        bool Start();
        bool Stop();
    }
}
