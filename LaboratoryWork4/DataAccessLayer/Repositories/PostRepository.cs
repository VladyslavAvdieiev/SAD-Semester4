using System;
using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class PostRepository : IRepository<Post> {
        private BoardContext db;

        public PostRepository(BoardContext context) {
            db = context;
        }

        public IEnumerable<Post> GetAll() {
            return db.Posts;
        }

        public Post Get(int id) {
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> Find(Func<Post, bool> predicate) {
            return db.Posts.Where(predicate).ToList();
        }

        public void Create(Post post) {
            db.Posts.Add(post);
        }

        public void Update(Post post) {
            db.Entry(post).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }
    }
}
