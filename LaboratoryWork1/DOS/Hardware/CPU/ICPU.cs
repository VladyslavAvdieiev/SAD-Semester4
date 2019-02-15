using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface ICPU {
        string Title { get; }
        bool IsEnabled { get; }
        int Cores { get; }
        double Frequency { get; }
        double PowerUsage { get; }
        double MemoryUsage { get; }
        void Enable();
        void Disable();
        void AddOwner(IDevice owner);
    }
}
