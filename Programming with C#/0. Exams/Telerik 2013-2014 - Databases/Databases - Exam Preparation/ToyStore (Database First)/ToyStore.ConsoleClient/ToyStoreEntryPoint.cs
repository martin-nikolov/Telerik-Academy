namespace ToyStore.ConsoleClient
{
    using System;
    using System.Linq;
    using ToyStore.Data;
    using ToyStore.DataGenerators.Contracts;
    using ToyStore.DatabaseSeeder;
    using ToyStore.DatabaseSeeder.Contracts;

    public class ToyStoreEntryPoint
    {
        private static readonly ToyStoreContext toyStoreContext;
        private static readonly ILogger consoleLogger;
        private static readonly ISeeder databaseSeeder;

        static ToyStoreEntryPoint()
        {
            toyStoreContext = new ToyStoreContext();
            consoleLogger = new ConsoleLogger();
            databaseSeeder = new DatabaseSeederWithRandomValues(toyStoreContext, consoleLogger);
        }

        internal static void Main()
        {
            using (toyStoreContext)
            {
                toyStoreContext.Configuration.AutoDetectChangesEnabled = false;

                var isDatabaseCreated = toyStoreContext.Database.CreateIfNotExists();
                if (isDatabaseCreated || !toyStoreContext.Toys.Any())
                {
                    databaseSeeder.SeedDatabaseWithRandomData();
                }
            }
        }
    }
}