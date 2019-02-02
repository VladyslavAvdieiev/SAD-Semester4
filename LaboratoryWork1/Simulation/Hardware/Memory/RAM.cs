using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class RAM : IInternalMemory {
        private IDevice _owner;
        private double _usedSpace;

        public event EventHandler<MemoryEventArgs> OnSpaceChanged;
        public event EventHandler<MemoryEventArgs> OnErrorOccurred;

        public string Title { get; }
        public double Capacity { get; }
        public double FreeSpace { get => Capacity - UsedSpace; }
        public double UsedSpace {
            get => _usedSpace;
            set {
                if (value < 0 || value > Capacity) {
                    OnErrorOccurred?.Invoke(this, new MemoryEventArgs("There is not enough memory"));
                    throw new ArgumentOutOfRangeException();
                }
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("Space has been changed"));
                _usedSpace = value;
            }
        }

        public RAM(string title, double capacity, IDevice owner) {
            Title = title;
            Capacity = capacity;
            _owner = owner;
        }

        public bool Format() {
            if (IsEmpty()) {
                OnErrorOccurred?.Invoke(this, new MemoryEventArgs("The drive had been formatted"));
                return false;
            }
            if (_owner.InProgress) {
                OnErrorOccurred?.Invoke(this, new MemoryEventArgs("Internal memory cannot be formatted while device is processing"));
                return false;
            }
            UsedSpace = 0d;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been formatted"));
            return true;
        }

        private bool IsEmpty() {
            return UsedSpace == 0d;
        }
    }
}
