using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class TxtFileNameCreator : FileNameCreator {

        public TxtFileNameCreator(string name) : base(name) {

        }

        public override IFileType CreateFileType() {
            return new TxtType();
        }
    }
}
