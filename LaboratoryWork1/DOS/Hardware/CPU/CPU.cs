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
        public bool IsEnable { get; private set; }
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
            if (!_owner.InProgress)
                throw new HardwareCannotBeEnabledException("The owner device is not in progress");
            if (IsEnable)
                throw new HardwareCannotBeEnabledException("The CPU is already enabled");
            IsEnable = true;
            OnStatusChanged?.Invoke(this, new CPUEventArgs("The CPU has been enabled", Title, IsEnable));
        }

        public void Disable() {
            if (!IsEnable)
                throw new HardwareCannotBeDisabledException("The CPU is already disabled");
            IsEnable = false;
            OnStatusChanged?.Invoke(this, new CPUEventArgs("The CPU has been disabled", Title, IsEnable));
        }
    }
}
