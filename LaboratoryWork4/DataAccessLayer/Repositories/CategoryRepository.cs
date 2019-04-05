using System;
using DataAccessLayer.Entities;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IRepository<Category> {
        private BoardContext db;

        public CategoryRepository(BoardContext context) {
            db = context;
        }

        public IEnumerable<Category> GetAll() {
            return db.Categories;
        }

        public Category Get(int id) {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate) {
            return db.Categories.Where(predicate).ToList();
        }

        public void Create(Category category) {
            db.Categories.Add(category);
        }

        public void Update(Category category) {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
    }
}
