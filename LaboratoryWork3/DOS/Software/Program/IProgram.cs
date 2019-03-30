﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IProgram : ISoftware {
        bool NeedsNetworkConnection { get; }
        void AddOwner(IOperatingSystem owner);
    }
}
