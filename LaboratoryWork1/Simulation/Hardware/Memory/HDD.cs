﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class HDD : IExternalStorage {
        private double _usedSpace;

        public string Title { get; }
        public double Capacity { get; }
        public double UsedSpace {
            get => _usedSpace;
            private set {
                if (value < 0d)
                    throw new Exception(); // different
                if (value > Capacity)
                    throw new Exception(); // different
                _usedSpace = value;
            }
        }

        public event EventHandler<MemoryEventArgs> OnSpaceChanged;

        public HDD(string title, double capacity) {
            Title = title;
            Capacity = capacity;
        }

        public async Task Load(double space) {
            await Task.Run(() => {
                Thread.Sleep(100);
                UsedSpace += space;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been loaded", Capacity, UsedSpace));
            });
        }

        public async Task Unload(double space) {
            await Task.Run(() => {
                Thread.Sleep(100);
                UsedSpace -= space;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been unloaded", Capacity, UsedSpace));
            });
        }

        public async Task Format() {
            await Task.Run(() => {
                Thread.Sleep(1000);
                UsedSpace = 0d;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been formatted", Capacity, UsedSpace));
            });
        }
    }
}
