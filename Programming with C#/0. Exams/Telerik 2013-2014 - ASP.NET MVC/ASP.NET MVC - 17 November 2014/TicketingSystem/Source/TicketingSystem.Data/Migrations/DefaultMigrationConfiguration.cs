namespace iMOT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TicketingSystem.Data;
    using TicketingSystem.Data.Models;

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

            var manager = new User()
            {
                UserName = "manager@gmail.com",
            };

            userManager.Create(manager, "manager@gmail.com");

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
    }
}