using System;
using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IDisposable {
        private bool disposed;
        private BoardContext db;
        private CategoryRepository categoryRepository;
        private UserRepository userRepository;
        private PostRepository postRepository;
        private TagRepository tagRepository;

        public UnitOfWork(string connectionString) {
            db = new BoardContext(connectionString);
            disposed = false;
        }

        public IRepository<Category> Categories {
            get {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IRepository<User> Users {
            get {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Post> Posts{
            get {
                if (postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }

        public IRepository<Tag> Tags{
            get {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public void Save() {
            db.SaveChanges();
        }

        public void Dispose() {
            if (!disposed)
                db.Dispose();
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
