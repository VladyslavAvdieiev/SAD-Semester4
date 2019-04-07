using System;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.EntityFramework
{
    public class BoardContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public BoardContext(string connectionString) : base(connectionString)
        {

        }
    }
}
