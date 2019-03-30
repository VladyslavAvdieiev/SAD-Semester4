using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface ISoftware {
        string Title { get; }
        bool IsEnabled { get; }
        double PowerUsage { get; }
        double MemoryUsage { get; }
        double NeededStorage { get; }
        void Run();
        void Stop();
    }
}
