using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class MemoryEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public double Capacity { get; }
        public double UsedSpace { get; }
        public MemoryEventArgs(string message, string title, double capacity, double usedSpace) {
            Message = message;
            Title = title;
            Capacity = capacity;
            UsedSpace = usedSpace;
        }
    }
}
