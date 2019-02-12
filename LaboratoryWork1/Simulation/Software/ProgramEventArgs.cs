using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Software
{
    public class ProgramEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public bool InProgress { get; }
        public ProgramEventArgs(string message, string title, bool inProgress) {
            Message = message;
            Title = title;
            InProgress = inProgress;
        }
    }
}
