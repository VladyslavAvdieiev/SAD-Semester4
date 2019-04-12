using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual User Author { get; set; }
        public virtual Category Category { get; set; }
        public List<string> Tags { get; set; }

        public Post(string title)
        {
            Title = title;
            Tags = new List<string>();
        }
    }
}
