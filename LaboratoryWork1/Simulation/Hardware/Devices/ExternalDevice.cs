using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class ExternalDevice : IExternalDevice {
        public string Title { get; }
        public double PowerUsage { get; }

        public ExternalDevice(string title, double powerUsage){
            Title = title;
            PowerUsage = powerUsage;
        }
    }
}
