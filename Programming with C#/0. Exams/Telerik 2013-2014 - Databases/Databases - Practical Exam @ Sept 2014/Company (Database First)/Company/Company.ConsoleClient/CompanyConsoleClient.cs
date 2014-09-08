namespace Company.ConsoleClient
{
    using System;
    using System.Linq;
    using Company.Data;
    using Company.DatabaseSeeder;
    using Company.DatabaseSeeder.Contracts;

    public class CompanyConsoleClient
    {
        private static readonly CompanyDbContext companyDbContext;
        private static readonly ISeeder databaseSeeder;

        static CompanyConsoleClient()
        {
            companyDbContext = new CompanyDbContext();
            databaseSeeder = new DatabaseSeederWithRandomValues(companyDbContext);
        }

        internal static void Main()
        {
            using (companyDbContext)
            {
                companyDbContext.Configuration.AutoDetectChangesEnabled = false;
                companyDbContext.Database.CreateIfNotExists();
              
                databaseSeeder.SeedDatabaseWithRandomData();
            }
        }
    }
}