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
    public class UserRepository : IRepository<User> {
        private BoardContext db;

        public UserRepository(BoardContext context) {
            db = context;
        }

        public IEnumerable<User> GetAll() {
            return db.Users;
        }

        public User Get(int id) {
            return db.Users.Find(id);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate) {
            return db.Users.Where(predicate).ToList();
        }

        public void Create(User user) {
            db.Users.Add(user);
        }

        public void Update(User user) {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id) {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
