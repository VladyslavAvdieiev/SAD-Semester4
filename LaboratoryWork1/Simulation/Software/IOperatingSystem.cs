using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public interface IOperatingSystem : ISoftware {
        IList<IProgram> Programs { get; }
        bool HasNetworkConnection { get; }
        Task Install(IProgram program);
        Task Uninstall(IProgram program);
    }
}
