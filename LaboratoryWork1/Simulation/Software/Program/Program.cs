using System;
using Simulation.Hardware;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public class Program : IProgram {
        private IDevice _owner;

        public event EventHandler<ProgramEventArgs> OnStatusChanged;
        public event EventHandler<ProgramEventArgs> OnErrorOccurred;

        public string Title { get; }
        public bool NeedsNetwork { get; }
        public bool InProgress { get; private set; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }
        public double Storage { get; }

        public Program(string title, bool needsNetwork, double powerUsage, double memoryUsage, double storage, IDevice owner) {
            Title = title;
            NeedsNetwork = needsNetwork;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            Storage = storage;
            _owner = owner;
        }

        public bool Start() {
            if (InProgress) {
                OnErrorOccurred?.Invoke(this, new ProgramEventArgs("The program is already in progress"));
                return false;
            }
            if (NeedsNetwork && !_owner.HasNetworkConnection) {
                OnErrorOccurred?.Invoke(this, new ProgramEventArgs("Some network connection troubles have just appeared"));
                return false;
            }
            if (_owner.InProgress) {
                OnErrorOccurred?.Invoke(this, new ProgramEventArgs("Program cannot start while device is not progressing"));
                return false;
            }
            InProgress = true;
            OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has started working"));
            return true;
        }

        public bool Stop() {
            if (!InProgress) {
                OnErrorOccurred?.Invoke(this, new ProgramEventArgs("The program is not in progress"));
                return false;
            }
            InProgress = false;
            OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has stopped working"));
            return true;
        }
    }
}
