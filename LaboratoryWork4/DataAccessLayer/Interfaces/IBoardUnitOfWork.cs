using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IBoardUnitOfWork : IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Post> Posts { get; }
        IRepository<User> Users { get; }
    }
}
