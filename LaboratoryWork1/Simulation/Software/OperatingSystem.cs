using System;
using Simulation.Hardware;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Simulation.Software
{
    public class OperatingSystem : IOperatingSystem {
        private IDevice _owner;
        private List<IProgram> _programs;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }
        public double NeededStorage { get; }
        public IList<IProgram> Programs { get => _programs.AsReadOnly(); }
        public bool HasNetworkConnection { get => _owner.HasNetworkConnection; }
       
        public event EventHandler<ProgramEventArgs> OnStatusChanged;

        public OperatingSystem(string title, double powerUsage, double memoryUsage, double neededStorage, IDevice owner) {
            Title = title;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            NeededStorage = neededStorage;
            _owner = owner;
        }

        public async Task Run() {
            await Task.Run(() => {
                Thread.Sleep(100);
                if (InProgress)
                    throw new Exception();
                if (!_owner.InProgress)
                    throw new Exception();
                InProgress = true;
                OnStatusChanged?.Invoke(this, new ProgramEventArgs("The operating system has started working"));
            });
        }

        public async Task Stop() {
            await Task.Run(() => {
                Thread.Sleep(100);
                if (!InProgress)
                    throw new Exception();
                InProgress = false;
                OnStatusChanged?.Invoke(this, new ProgramEventArgs("The operating system has stopped working"));
            });
        }

        public async Task Install(IProgram program) {
            throw new NotImplementedException();
        }

        public async Task Uninstall(IProgram program) {
            throw new NotImplementedException();
        }
    }
}
