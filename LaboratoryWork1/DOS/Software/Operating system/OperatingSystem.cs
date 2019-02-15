using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class OperatingSystem : IOperatingSystem {
        private IDevice _owner;
        private List<IProgram> _programs;

        public string Title { get; }
        public bool IsEnabled { get; private set; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }
        public double NeededStorage { get; }
        public IList<IProgram> Programs { get => _programs.AsReadOnly(); }
        public bool HasNetworkConnection { get => _owner.HasNetworkConnection; }

        public event EventHandler<SoftwareEventArgs> OnStatusChanged;

        public OperatingSystem(string title, double powerUsage, double memoryUsage, double neededStorage, IDevice owner) {
            Title = title;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            NeededStorage = neededStorage;
            _owner = owner;
            _programs = new List<IProgram>();
        }

        public void Run() {
            if (!_owner.IsEnabled)
                throw new SoftwareCannotBeEnabledException("The owner device is not enabled");
            if (IsEnabled)
                throw new SoftwareCannotBeEnabledException("The OS is already enabled");
            IsEnabled = true;
            Task.Run(() => StartUsingRAM());
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The OS has been enabled", Title, IsEnabled));
        }

        private void StartUsingRAM() {
            throw new NotImplementedException();
        }

        public void Stop() {
            if (!IsEnabled)
                throw new SoftwareCannotBeDisabledException("The OS is already disabled");
            IsEnabled = false;
            StopPrograms();
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The OS has been disabled", Title, IsEnabled));
        }

        private void StopPrograms() {
            foreach (IProgram program in _programs)
                if (program.IsEnabled)
                    program.Stop();
        }

        public void Install(IProgram program) {
            throw new NotImplementedException();
        }

        public void Uninstall(IProgram program) {
            throw new NotImplementedException();
        }
    }
}
