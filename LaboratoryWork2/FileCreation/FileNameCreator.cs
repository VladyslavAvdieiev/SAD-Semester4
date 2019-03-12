using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public abstract class FileNameCreator {
        private readonly string _name;

        public FileNameCreator(string name) {
            _name = name;
        }

        public string GetName() {
            IFileType fileType = CreateFileType();
            return string.Concat(_name, fileType);
        }

        public abstract IFileType CreateFileType();
    }
}
