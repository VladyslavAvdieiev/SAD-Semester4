using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IOperatingSystem : ISoftware {
        IList<IProgram> Programs { get; }
        bool HasNetworkConnection { get; }
        void Install(IProgram program);
        void Uninstall(IProgram program);
    }
}
