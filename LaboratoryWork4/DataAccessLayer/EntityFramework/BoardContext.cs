using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class BoardContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public BoardContext() : base()
        {

        }
    }
}
