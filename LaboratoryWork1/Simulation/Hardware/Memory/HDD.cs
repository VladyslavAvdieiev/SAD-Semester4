﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class HDD : IExternalStorage {
        private double _freeSpace;

        public event EventHandler<MemoryEventArgs> OnSpaceChanged;
        public event EventHandler<MemoryEventArgs> OnErrorOccurred;

        public string Title { get; }
        public double Capacity { get; }
        public double FreeSpace {
            get => _freeSpace;
            set {
                if (value < 0 || value > Capacity) {
                    OnErrorOccurred?.Invoke(this, new MemoryEventArgs("There is not enough memory"));
                    throw new OutOfMemoryException();
                }
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("Space has changed"));
                _freeSpace = value;
            }
        }

        public HDD(string title, double capacity) {
            Title = title;
            Capacity = capacity;
            FreeSpace = capacity;
        }

        public bool Format() {
            FreeSpace = Capacity;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has formatted"));
            return true;
        }
    }
}
