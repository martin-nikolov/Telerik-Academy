namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using ForumSystem.Common;
    using ForumSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUsers(context);
            this.SeedTags(context);
            this.SeedPosts(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var admin = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
            };

            userManager.Create(admin, "admin@gmail.com");

            for (int i = 0; i < 10; i++)
            {
                var user = new ApplicationUser
                {
                    Email = string.Format("{0}@{1}.com",
                        RandomDataGenerator.Instance.GetRandomString(6, 16),
                        RandomDataGenerator.Instance.GetRandomString(6, 16)),
                    UserName = RandomDataGenerator.Instance.GetRandomString(6, 16)
                };

                userManager.Create(user, "123456");
            }

            context.SaveChanges();
        }
 
        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            var numberOfTags = RandomDataGenerator.Instance.GetRandomInt(10, 25);
            for (int i = 0; i < numberOfTags; i++)
            {
                var tag = new Tag()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(5, 10)
                };

                context.Tags.Add(tag);
            }

            context.SaveChanges();
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var allTags = context.Tags.ToList();
            var users = context.Users.ToList();

            var numberOfPosts = RandomDataGenerator.Instance.GetRandomInt(10, 20);
            for (int i = 0; i < numberOfPosts; i++)
            {
                users = users.OrderBy(x => RandomDataGenerator.Instance.Next()).ToList();

                var title = RandomDataGenerator.Instance.GetRandomString(5, 20) + " " +
                            RandomDataGenerator.Instance.GetRandomString(5, 20) + " " +
                            RandomDataGenerator.Instance.GetRandomString(0, 10);

                var content = new StringBuilder();

                for (int j = 0; j < 15; j++)
                {
                    content.AppendFormat(" {0}", RandomDataGenerator.Instance.GetRandomString(5, 30));
                }

                var post = new Post()
                {
                    Title = title,
                    Content = content.ToString(),
                    AuthorId = users.First().Id
                };

                var numberOfTagsInPost = RandomDataGenerator.Instance.GetRandomInt(4, 7);
                allTags = allTags.OrderBy(x => RandomDataGenerator.Instance.Next()).ToList();

                for (int j = 0; j < numberOfTagsInPost; j++)
                {
                    post.Tags.Add(allTags[j]);
                }

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }
    }
}