namespace ToyStore.DatabaseSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyStore.Data.Contracts;
    using ToyStore.DataGenerators;
    using ToyStore.DataGenerators.Contracts;
    using ToyStore.DatabaseSeeder.Contracts;

    public class DatabaseSeederWithRandomValues : ISeeder
    {
        private const int CategoriesCount = 100;
        private const int ManufacturersCount = 50;
        private const int AgeRangesCount = 100;
        private const int ToysCount = 20000;

        private readonly IToyStoreContext toyStoreContext;
        private readonly ILogger logger;

        public DatabaseSeederWithRandomValues(IToyStoreContext toyStoreContext, ILogger logger)
        {
            this.toyStoreContext = toyStoreContext;
            this.logger = logger;
        }

        public void SeedDatabaseWithRandomData()
        {
            var dataGenerators = new List<IDataGenerator>()
            {
                new CategoryGenerator(this.toyStoreContext, CategoriesCount, this.logger),
                new ManufacturerGenerator(this.toyStoreContext, ManufacturersCount, this.logger),
                new AgeRangeGenerator(this.toyStoreContext, AgeRangesCount, this.logger),
                new ToyGenerator(this.toyStoreContext, ToysCount, this.logger)
            };

            foreach (var dataGenerator in dataGenerators)
            {
                dataGenerator.Seed();
            }
        }
    }
}