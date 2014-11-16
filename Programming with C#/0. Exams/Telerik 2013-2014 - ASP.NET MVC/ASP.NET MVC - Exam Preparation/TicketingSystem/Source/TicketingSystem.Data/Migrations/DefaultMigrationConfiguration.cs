namespace iMOT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Common;
    using TicketingSystem.Data;
    using TicketingSystem.Data.Models;
    using TicketingSystem.Data.Models.Enums;

    internal sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<TicketingSystemDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketingSystemDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
            this.SeedCategoriesWithTicketsWithComments(context);
        }

        private void SeedAdmin(TicketingSystemDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var admin = new User()
            {
                UserName = "admin@gmail.com",
            };

            userManager.Create(admin, "admin@gmail.com");
            userManager.AddToRole(admin.Id, "Admin");

            for (int i = 0; i < 10; i++)
            {
                var user = new User
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

        private void SeedRoles(TicketingSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = "Admin" };
            roleManager.Create(adminRole);

            context.SaveChanges();
        }

        private void SeedCategoriesWithTicketsWithComments(TicketingSystemDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var image = this.GetDefaultImage();
            var users = context.Users.Take(10).ToList();
            for (int i = 0; i < 5; i++)
            {
                var category = new Category
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(5, 20)
                };

                for (int j = 0; j < 10; j++)
                {
                    var ticket = new Ticket
                    {
                        Author = users[RandomDataGenerator.Instance.GetRandomInt(0, users.Count - 1)],
                        Title = RandomDataGenerator.Instance.GetRandomString(5, 40),
                        Description = RandomDataGenerator.Instance.GetRandomString(200, 500),
                        Image = image,
                        Priority = (PriorityType)RandomDataGenerator.Instance.GetRandomInt(0, 2)
                    };

                    for (int k = 0; k < 5; k++)
                    {
                        var comment = new Comment
                        {
                            Author = users[RandomDataGenerator.Instance.GetRandomInt(0, users.Count - 1)],
                            Content = RandomDataGenerator.Instance.GetRandomString(100, 200)
                        };

                        ticket.Comments.Add(comment);
                    }

                    category.Tickets.Add(ticket);
                }

                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        private Image GetDefaultImage()
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembly(Assembly.GetExecutingAssembly());
            var file = File.ReadAllBytes(directory + "/Images/default.png");
            var image = new Image
            {
                Content = file,
                FileExtension = "png"
            };

            return image;
        }
    }
}