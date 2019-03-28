using System;
using FileCreation.FileTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class JpegFileNameCreator : FileNameCreator {

        public JpegFileNameCreator(string name) : base(name) {

        }

        public override IFileType CreateFileType() {
            return new JpegType();
        }
    }
}
