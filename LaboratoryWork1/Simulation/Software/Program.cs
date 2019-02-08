using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Simulation.Software
{
    public class Program : IProgram {
        private IOperatingSystem _owner;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public bool NeedsNetworkConnection { get; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }
        public double NeededStorage { get; }

        public event EventHandler<ProgramEventArgs> OnStatusChanged;

        public Program(string title, bool needsNetwork, double powerUsage, double memoryUsage, double neededStorage, IOperatingSystem owner) {
            Title = title;
            NeedsNetworkConnection = needsNetwork;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            NeededStorage = neededStorage;
            _owner = owner;
        }

        public async Task Run() {
            await Task.Run(() =>{
                Thread.Sleep(100);
                if (InProgress)
                    throw new Exception();
                if (!_owner.InProgress)
                    throw new Exception();
                if (NeedsNetworkConnection && !_owner.HasNetworkConnection)
                    throw new Exception();
                InProgress = true;
                OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has started working"));
            });
        }

        public async Task Stop() {
            await Task.Run(() => {
                Thread.Sleep(100);
                if (!InProgress)
                    throw new Exception();
                InProgress = false;
                OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has stopped working"));
            });
        }
    }
}
