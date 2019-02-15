using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class CPUEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public bool IsEnable { get; }
        public CPUEventArgs(string message, string title, bool isEnable) {
            Message = message;
            Title = title;
            IsEnable = isEnable;
        }
    }
}
