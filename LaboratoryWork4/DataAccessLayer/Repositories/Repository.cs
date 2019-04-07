using System;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        private BoardContext context;

        public Repository(BoardContext context) {
            this.context = context;
        }

        public void Create(TEntity item) {
            context.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item) {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item) {
            context.Set<TEntity>().Remove(item);
        }

        public void Delete(Func<TEntity, bool> where) {
            IEnumerable<TEntity> entities = context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (TEntity entity in entities)
                context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Func<TEntity, bool> where) {
            return context.Set<TEntity>().Find(where);
        }

        public IEnumerable<TEntity> GetAll() {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> where) {
            return context.Set<TEntity>().Where(where).ToList();
        }
    }
}
