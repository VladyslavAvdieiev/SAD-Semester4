using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public class OS : IOS {
        public string Title { get; }
        public double MemoryUsage { get; }

        public OS(string title, double memoryUsage) {
            Title = title;
            MemoryUsage = memoryUsage;
        }
    }
}
