using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface ICPU {
        string Title { get; }
        int Cores { get; }
        double Frequency { get; }
        double PowerUsage { get; }
    }
}
