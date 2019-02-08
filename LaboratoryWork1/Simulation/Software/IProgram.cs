using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public interface IProgram : ISoftware {
        bool NeedsNetworkConnection { get; }
    }
}
