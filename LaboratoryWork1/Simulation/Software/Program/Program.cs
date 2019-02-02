using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public class Program : IProgram {
        public string Title { get; }
        public bool NeedsNetwork { get; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }

        public Program(string title, bool needsNetwork, double powerUsage, double memoryUsage) {
            Title = title;
            NeedsNetwork = needsNetwork;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
        }

        public bool Start() {
            throw new NotImplementedException();
        }

        public bool Stop() {
            throw new NotImplementedException();
        }
    }
}
