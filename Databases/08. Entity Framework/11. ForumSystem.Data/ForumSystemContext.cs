namespace ForumSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ForumSystem.Data.Migrations;
    using ForumSystem.Models;

    public class ForumSystemContext : DbContext
    {
        const string DatabaseName = "ForumSystem";

        public ForumSystemContext()
            : base(DatabaseName)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumSystemContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}