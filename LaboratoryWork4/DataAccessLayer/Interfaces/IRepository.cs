using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class {
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        void Delete(Func<TEntity, bool> where);

        TEntity Get(Func<TEntity, bool> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> where);
    }
}
