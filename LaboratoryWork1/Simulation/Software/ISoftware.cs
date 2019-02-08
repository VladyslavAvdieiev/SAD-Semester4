using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public interface ISoftware {
        string Title { get; }
        bool InProgress { get; }
        double PowerUsage { get; }
        double MemoryUsage { get; }
        double NeededStorage { get; }
        Task Run();
        Task Stop();
    }
}
