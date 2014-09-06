namespace ToyStore.DataGenerators
{
    using System;
    using System.Linq;
    using ToyStore.Common;
    using ToyStore.Data.Contracts;
    using ToyStore.Data.Models;
    using ToyStore.DataGenerators.Abstracts;
    using ToyStore.DataGenerators.Contracts;

    public class CategoryGenerator : DataGeneratorAbstract
    {
        private const int MinLength = 4;
        private const int MaxLength = 10;

        public CategoryGenerator(IToyStoreContext toyStoreContext, int seedDataCount, ILogger logger)
            : base(toyStoreContext, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            for (int i = 0; i < this.SeedDataCount; i++) 
            {
                var category = new Category()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinLength, MaxLength)
                };

                this.ToyStoreContext.Categories.Add(category);

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