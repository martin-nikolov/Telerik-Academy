namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ForumSystem.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ForumSystem.Data.ForumSystemContext";
        }
    }
}