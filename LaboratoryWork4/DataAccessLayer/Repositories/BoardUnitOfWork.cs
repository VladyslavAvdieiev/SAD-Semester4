using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BoardUnitOfWork : IBoardUnitOfWork
    {
        private bool isDisposed;
        private BoardContext context;
        private IRepository<Category> categoryRepository;
        private IRepository<Post> postRepository;
        private IRepository<User> userRepository;

        public BoardUnitOfWork()
        {
            context = new BoardContext();
            isDisposed = false;
        }

        public IRepository<Category> Categories
        {
            get => categoryRepository ?? (categoryRepository = new Repository<Category>(context));
        }

        public IRepository<Post> Posts
        {
            get => postRepository ?? (postRepository = new Repository<Post>(context));
        }

        public IRepository<User> Users
        {
            get => userRepository ?? (userRepository = new Repository<User>(context));
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                context.Dispose();
                isDisposed = true;
            }
        }
    }
}
