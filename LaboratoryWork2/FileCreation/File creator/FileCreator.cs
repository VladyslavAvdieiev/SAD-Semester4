using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public static class FileCreator {

        public static void Create(FileNameCreator file) {
            File.Create(file.GetName());
        }
    }
}
