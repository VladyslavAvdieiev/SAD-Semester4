using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }

        public Post() {

        }

        public Post(string title) {
            Title = title;
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;
            if (GetHashCode() != obj.GetHashCode())
                return false;
            return true;
        }
        
        public override int GetHashCode() {
            return Id.GetHashCode() + Title.GetHashCode() + Description.GetHashCode();
        }

        public override string ToString() {
            return $"ID:{Id} {Title}";
        }
    }
}
