using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class CPU : ICPU {
        public string Title { get; }
        public int Cores { get; }
        public double Frequency { get; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }

        public CPU(string title, int cores, double frequency, double powerUsage, double memoryUsage) {
            Title = title;
            Cores = cores;
            Frequency = frequency;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
        }
    }
}
