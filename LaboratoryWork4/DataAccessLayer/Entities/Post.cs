using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Post()
        {

        }

        public Post(string title)
        {
            Title = title;
        }
    }
}
