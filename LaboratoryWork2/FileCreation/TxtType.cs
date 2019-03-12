using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCreation
{
    public class TxtType : IType {
        private string _name;
        private const string _type = ".txt";

        public TxtType(string name) {
            _name = string.Concat(name, _type);
        }

        public string GetName() {
            return _name;
        }
    }
}
