using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public OperatingSystem(string title, double powerUsage, double memoryUsage, double neededStorage) {
            Title = title;
            PowerUsage = powerUsage;
            MemoryUsage = memoryUsage;
            NeededStorage = neededStorage;
            _programs = new List<IProgram>();
        }

        public void Run() {
            if (!_owner.IsEnabled)
                throw new SoftwareCannotBeEnabledException("The owner device is not enabled");
            if (IsEnabled)
                throw new SoftwareCannotBeEnabledException("The OS is already enabled");
            IsEnabled = true;
            _owner.CPU.Enable();
            Task.Run(() => StartUsingRAM());
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The OS has been enabled", Title, IsEnabled));
        }

        private void StartUsingRAM() {
            double total;
            while (IsEnabled) {
                total = 0d;
                total += _owner.CPU.MemoryUsage;
                total += _owner.OperatingSystem.MemoryUsage;
                foreach (IProgram program in _programs)
                    if (program.IsEnabled)
                        total += program.MemoryUsage;
                if (total != _owner.RAM.UsedSpace)
                    if (total > _owner.RAM.UsedSpace)
                        _owner.RAM.Load(total - _owner.RAM.UsedSpace);      // DEBUG NotEnoughMemoryException
                    else
                        _owner.RAM.Unload(_owner.RAM.UsedSpace - total);    // DEBUG NotEnoughMemoryException
                Thread.Sleep(1000);
            }
        }

        public void Stop() {
            if (!IsEnabled)
                throw new SoftwareCannotBeDisabledException("The OS is already disabled");
            IsEnabled = false;
            StopPrograms();
            _owner.CPU.Disable();
            _owner.RAM.Dispose();
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The OS has been disabled", Title, IsEnabled));
        }

        private void StopPrograms() {
            foreach (IProgram program in _programs)
                if (program.IsEnabled)
                    program.Stop();
        }

        public void Install(IProgram program) {
            _owner.ExternalStorage.Load(program.NeededStorage);             // DEBUG NotEnoughMemoryException
            program.AddOwner(this);
            _programs.Add(program);
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The program has been successfully installed", Title, IsEnabled));
        }

        public void Uninstall(IProgram program) {
            if (!_programs.Contains(program))
                throw new UnknownSoftwareException("Such program does not exist");
            _owner.ExternalStorage.Unload(program.NeededStorage);           // DEBUG DriveIsEmptyException
            _programs.Remove(program);
            OnStatusChanged?.Invoke(this, new SoftwareEventArgs("The program has been successfully uninstalled", Title, IsEnabled));
        }

        public void AddOwner(IDevice owner) {
            _owner = owner;
        }
    }
}
