﻿using System;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class PersonalComputer : IDevice {
        private List<IProgram> _programs;
        private List<IExternalDevice> _externalDevices;

        public event EventHandler<DeviceEventArgs> OnStatusChanged;
        public event EventHandler<DeviceEventArgs> OnErrorOccurred;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public IOS OS { get; }
        public ICPU CPU { get; }
        public IBattery Battery { get; set; }
        public IInternalMemory RAM { get; }
        public IExternalStorage ExternalStorage { get; }
        public IList<IProgram> Programs { get => _programs.AsReadOnly(); }
        public IList<IExternalDevice> ExternalDevices { get => _externalDevices.AsReadOnly(); }
        public bool HasElectricityConnection { get; set; }
        public bool HasNetworkConnection { get; set; }

        public PersonalComputer(string title, IOS os, ICPU cpu, IBattery battery, IInternalMemory ram, 
            IExternalStorage externalStorage, bool hasElectricityConnection, bool hasNetworkConnection)
        {
            Title = title;
            OS = os;
            CPU = cpu;
            Battery = battery;
            RAM = ram;
            ExternalStorage = externalStorage;
            _programs = new List<IProgram>();
            _externalDevices = new List<IExternalDevice>();
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }

        public bool TurnOn() {
            throw new NotImplementedException();
        }

        public bool TurnOff() {
            throw new NotImplementedException();
        }
    }
}
