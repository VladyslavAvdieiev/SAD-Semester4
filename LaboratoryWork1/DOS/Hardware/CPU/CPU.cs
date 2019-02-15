using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class CPU : ICPU {
        private IDevice _owner;

        public string Title { get; }
        public bool IsEnabled { get; private set; }
        public int Cores { get; }
        public double Frequency { get; }
        public double PowerUsage { get; }
        public double MemoryUsage { get; }

        public event EventHandler<CPUEventArgs> OnStatusChanged;

        public CPU(string title, int cores, double frequency, double memoryUsage, IDevice owner) {
            Title = title;
            Cores = cores;
            Frequency = frequency;
            MemoryUsage = memoryUsage;
            PowerUsage = Frequency * Cores / 10;
            _owner = owner;
        }

        public void Enable() {
            if (!_owner.IsEnabled)
                throw new HardwareCannotBeEnabledException("The owner device is not enabled");
            if (IsEnabled)
                throw new HardwareCannotBeEnabledException("The CPU is already enabled");
            IsEnabled = true;
            OnStatusChanged?.Invoke(this, new CPUEventArgs("The CPU has been enabled", Title, IsEnabled));
        }

        public void Disable() {
            if (!IsEnabled)
                throw new HardwareCannotBeDisabledException("The CPU is already disabled");
            IsEnabled = false;
            OnStatusChanged?.Invoke(this, new CPUEventArgs("The CPU has been disabled", Title, IsEnabled));
        }
    }
}
