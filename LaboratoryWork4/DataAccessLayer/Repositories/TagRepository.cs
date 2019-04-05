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
    public class TagRepository : IRepository<Tag> {
        private BoardContext db;

        public TagRepository(BoardContext context) {
            db = context;
        }

        public IEnumerable<Tag> GetAll() {
            return db.Tags;
        }

        public Tag Get(int id) {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate) {
            return db.Tags.Where(predicate).ToList();
        }

        public void Create(Tag tag) {
            db.Tags.Add(tag);
        }

        public void Update(Tag tag) {
            db.Entry(tag).State = EntityState.Modified;
        }

        public void Delete(int id) {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Tags.Remove(tag);
        }
    }
}
