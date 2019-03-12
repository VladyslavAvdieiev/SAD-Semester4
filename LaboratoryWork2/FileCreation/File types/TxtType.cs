using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class TxtType : IFileType {
        private const string type = ".txt";

        public override string ToString() {
            return type;
        }
    }
}
