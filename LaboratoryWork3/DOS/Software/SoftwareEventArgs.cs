using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class SoftwareEventArgs : EventArgs {
        public string Message { get; }
        public string Title { get; }
        public bool IsEnabled { get; }
        public SoftwareEventArgs(string message, string title, bool isEnabled) {
            Message = message;
            Title = title;
            IsEnabled = isEnabled;
        }
    }
}
