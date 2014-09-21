namespace BugLogger.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BugLogger.Common;
    using BugLogger.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BugLoggerDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BugLoggerDbContext context)
        {
            this.SeedBugs(context);
        }

        private void SeedBugs(BugLoggerDbContext context)
        {
            if (context.Bugs.Any())
            {
                return;
            }

            int numberOfBugsToSeed = 1000;
            for (int i = 0; i < numberOfBugsToSeed; i++)
            {
                var bug = new Bug()
                {
                    Description = RandomDataGenerator.Instance.GetRandomString(5, 50),
                    LogDate = RandomDataGenerator.Instance.GetRandomDate(),
                    Status = (BugStatus)RandomDataGenerator.Instance.GetRandomInt(0, 3)
                };

                context.Bugs.Add(bug);
            }

            context.SaveChanges();
        }
    }
}