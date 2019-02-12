using System;
using Simulation.Hardware;
using Simulation.Exceptions;
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
            _programs = new List<IProgram>();
        }

        public async Task Run() {
            await Task.Run(() => {
                Thread.Sleep(100);
                if (InProgress)
                    throw new SoftwareCannotBeStartedException();
                if (!_owner.InProgress)
                    throw new SoftwareCannotBeStartedException();
                InProgress = true;
                UseRAM();
                OnStatusChanged?.Invoke(this, new ProgramEventArgs("The operating system has started working", Title, InProgress));
            });
        }

        public async Task Stop() {
            if (!InProgress)
                throw new SoftwareCannotBeStoppedException();
            InProgress = false;
            await StopPrograms();
            await _owner.RAM.Dispose();
            OnStatusChanged?.Invoke(this, new ProgramEventArgs("The operating system has stopped working", Title, InProgress));
        }

        public async Task Install(IProgram program) {
            await _owner.ExternalStorage.Load(program.NeededStorage);
            _programs.Add(program);
            OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has been successfully installed", Title, InProgress));
        }

        public async Task Uninstall(IProgram program) {
            if (!_programs.Contains(program))
                throw new UnknownProgramException();
            await _owner.ExternalStorage.Unload(program.NeededStorage);
            _programs.Remove(program);
            OnStatusChanged?.Invoke(this, new ProgramEventArgs("The program has been successfully installed", Title, InProgress));
        }

        private async Task UseRAM() {
            await Task.Run(() => {
                double total;
                while (InProgress) {
                    Thread.Sleep(1000);
                    total = 0d;
                    total += _owner.CPU.MemoryUsage;
                    total += _owner.OperatingSystem.MemoryUsage;
                    foreach (IProgram program in _programs)
                        if (program.InProgress)
                            total += program.MemoryUsage;
                    if (total != _owner.RAM.UsedSpace)
                        if (total > _owner.RAM.UsedSpace)
                            _owner.RAM.Load(total - _owner.RAM.UsedSpace);
                        else
                            _owner.RAM.Unload(_owner.RAM.UsedSpace - total);
                }
            });
        }

        private async Task StopPrograms() {
            foreach (IProgram program in _programs)
                if (program.InProgress)
                    await program.Stop();
        }
    }
}
