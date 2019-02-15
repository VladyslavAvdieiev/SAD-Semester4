using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class Program : IProgram {
        public string Title { get; }
        public bool IsEnabled { get; private set; }
        public bool NeedsNetworkConnection { get; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }
        public double NeededStorage { get; }

        public event EventHandler<SoftwareEventArgs> OnStatusChanged;

        public Program(string title, bool needsNetworkConnection, double powerUsage, double memoryUsage, double neededStorage) {
            Title = title;
            NeedsNetworkConnection = needsNetworkConnection;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            NeededStorage = neededStorage;
        }

        public void Run() {
            if (IsEnabled)
                throw new SoftwareCannotBeEnabledException("The program is already enabled");
            IsEnabled = true;
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The program has been enabled", Title, IsEnabled));
        }

        public void Stop() {
            if (!IsEnabled)
                throw new SoftwareCannotBeDisabledException("The program is already disabled");
            IsEnabled = false;
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The program has been disabled", Title, IsEnabled));
        }
    }
}
