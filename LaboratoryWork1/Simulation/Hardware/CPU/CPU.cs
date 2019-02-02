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

        public CPU(string title, int cores, double frequency, double memoryUsage) {
            Title = title;
            Cores = cores;
            Frequency = frequency;
            MemoryUsage = memoryUsage;
            PowerUsage = Frequency * Cores / 10;    // Frequency = 2.8
                                                    // Cores = 4
                                                    // PowerUsage = 2.8 * 4 / 10 = 1.12 per second
        }
    }
}
