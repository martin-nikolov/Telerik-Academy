namespace ToyStore.DataGenerators
{
    using System;
    using System.Linq;
    using ToyStore.Common;
    using ToyStore.Data.Contracts;
    using ToyStore.Data.Models;
    using ToyStore.DataGenerators.Abstracts;
    using ToyStore.DataGenerators.Contracts;

    public class ManufacturerGenerator : DataGeneratorAbstract
    {
        private const int MinLength = 3;
        private const int MaxLength = 10;

        public ManufacturerGenerator(IToyStoreContext toyStoreContext, int seedDataCount, ILogger logger)
            : base(toyStoreContext, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            var uniqueNames = RandomDataGenerator.Instance.GetUniqueStringsCollection(MinLength, MaxLength, this.SeedDataCount);

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var manufacturer = new Manufacturer()
                {
                    Name = uniqueNames[i],
                    Country = RandomDataGenerator.Instance.GetRandomString(MinLength, MaxLength)
                };

                this.ToyStoreContext.Manufacturers.Add(manufacturer);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreContext.SaveChanges();
                }
            }

            this.ToyStoreContext.SaveChanges();
            this.Logger.Log(Environment.NewLine);
        }
    }
}