using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IExternalDevice {
        string Title { get; }
        double PowerUsage { get; }
    }
}
