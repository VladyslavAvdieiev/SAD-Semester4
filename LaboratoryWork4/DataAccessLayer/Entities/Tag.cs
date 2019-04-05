using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Tag {
        public int Id { get; set; }
        public string Name { get; set; }

        public Tag() {

        }

        public Tag(string name) {
            Name = name;
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (GetHashCode() != obj.GetHashCode())
                return false;
            return true;
        }
        
        public override int GetHashCode() {
            return Id.GetHashCode() + Name.GetHashCode();
        }

        public override string ToString() {
            return Name;
        }
    }
}
