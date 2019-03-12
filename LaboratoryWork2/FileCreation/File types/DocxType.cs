using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class DocxType : IFileType {
        private const string type = ".docx";

        public override string ToString() {
            return type;
        }
    }
}
