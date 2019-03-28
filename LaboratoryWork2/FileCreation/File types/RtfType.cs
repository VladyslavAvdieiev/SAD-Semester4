using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation.FileTypes
{
    public class RtfType : IFileType {
        private const string type = ".rtf";

        public override string ToString() {
            return type;
        }
    }
}
