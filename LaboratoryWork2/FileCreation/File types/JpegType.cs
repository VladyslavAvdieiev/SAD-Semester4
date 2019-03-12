using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class JpegType : IFileType {
        private const string type = ".jpeg";

        public override string ToString() {
            return type;
        }
    }
}
