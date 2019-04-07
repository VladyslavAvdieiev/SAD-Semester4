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
    public class UnitOfWork : IUnitOfWork {
        private bool disposed;
        private BoardContext context;
        private IRepository<Category> categoryRepository;
        private IRepository<Post> postRepository;
        private IRepository<User> userRepository;

        public UnitOfWork(string connectionString) {
            context = new BoardContext(connectionString);
            disposed = false;
        }

        public IRepository<Category> Categories {
            get => categoryRepository ?? (categoryRepository = new Repository<Category>(context));
        }

        public IRepository<Post> Posts {
            get => postRepository ?? (postRepository = new Repository<Post>(context));
        }

        public IRepository<User> Users {
            get => userRepository ?? (userRepository = new Repository<User>(context));
        }

        public void Save() {
            context.SaveChanges();
        }

        public void Dispose() {
            if (!disposed)
                context.Dispose();
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
