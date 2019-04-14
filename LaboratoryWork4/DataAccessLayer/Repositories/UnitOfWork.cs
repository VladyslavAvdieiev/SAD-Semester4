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
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed;
        private BoardContext context;
        private IRepository<Category> categoryRepository;

        public UnitOfWork()
        {
            context = new BoardContext();
            isDisposed = false;
        }

        public IRepository<Category> Categories
        {
            get => categoryRepository ?? (categoryRepository = new Repository<Category>(context));
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

        public virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                context.Dispose();
                isDisposed = true;
            }
        }
    }
}
