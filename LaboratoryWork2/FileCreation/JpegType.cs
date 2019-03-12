using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class JpegType : IType {
        private string _name;
        private const string _type = ".jpeg";

        public JpegType(string name) {
            _name = string.Concat(name, _type);
        }

        public string GetName() {
            return _name;
        }
    }
}
