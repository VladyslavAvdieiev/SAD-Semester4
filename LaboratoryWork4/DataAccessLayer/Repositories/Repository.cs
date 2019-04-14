using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private BoardContext context;

        public Repository(BoardContext context)
        {
            this.context = context;
        }

        public void Create(TEntity item)
        {
            context.Entry(item).State = EntityState.Added;
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            context.Entry(item).State = EntityState.Deleted;
        }

        public void DeleteBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> items = context.Set<TEntity>().Where(predicate).AsEnumerable();
            foreach (TEntity item in items)
                context.Entry(item).State = EntityState.Deleted;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().First(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
