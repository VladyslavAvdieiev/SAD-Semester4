using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IMemory {
        string Title { get; }
        double Capacity { get; }
        double UsedSpace { get; }
        void Load(double space);
        void Unload(double space);
    }
}
