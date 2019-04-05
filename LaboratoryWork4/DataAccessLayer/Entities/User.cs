using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<Post> Posts { get; set; }

        public User() {
            Posts = new List<Post>();
        }

        public User(string nickname) {
            Nickname = nickname;
            Posts = new List<Post>();
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (GetHashCode() != obj.GetHashCode())
                return false;
            return true;
        }
        
        public override int GetHashCode() {
            return Id.GetHashCode() + FirstName.GetHashCode() + LastName.GetHashCode() + Nickname.GetHashCode();
        }

        public override string ToString() {
            return $"ID:{Id} {Nickname}";
        }
    }
}
