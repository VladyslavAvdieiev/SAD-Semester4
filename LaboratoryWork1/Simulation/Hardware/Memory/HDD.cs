using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class HDD : IExternalStorage {
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
                    throw new OutOfMemoryException();
                }
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("Space has changed"));
                _usedSpace = value;
            }
        }

        public HDD(string title, double capacity) {
            Title = title;
            Capacity = capacity;
        }

        public bool Format() {
            UsedSpace = 0d;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has formatted"));
            return true;
        }
    }
}
