using System;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class BoardDbInitializer : DropCreateDatabaseIfModelChanges<BoardContext> {

        protected override void Seed(BoardContext context) {
            Category category = new Category("Software");
            Tag tag1 = new Tag("Software");
            Tag tag2 = new Tag("Desktop");
            Post post = new Post("Soft development") { Description = "Develop soft foe money", Category = category};
            post.Tags.Add(tag1);
            post.Tags.Add(tag2);
            User user = new User("testnick") { FirstName = "Vladyslav", LastName = "Avdieiev" };
            user.Posts.Add(post);

            context.Users.Add(user);
            context.Categories.Add(category);
            context.Tags.Add(tag1);
            context.Tags.Add(tag2);
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
