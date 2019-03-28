using System;
using FileCreation.FileTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class DocxFileNameCreator : FileNameCreator {

        public DocxFileNameCreator(string name) : base(name) {

        }

        public override IFileType CreateFileType() {
            return new DocxType();
        }
    }
}
