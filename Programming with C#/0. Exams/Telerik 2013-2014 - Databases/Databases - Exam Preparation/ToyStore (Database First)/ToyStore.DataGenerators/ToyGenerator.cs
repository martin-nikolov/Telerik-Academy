namespace ToyStore.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToyStore.Common;
    using ToyStore.Data.Contracts;
    using ToyStore.Data.Models;
    using ToyStore.DataGenerators.Abstracts;
    using ToyStore.DataGenerators.Contracts;

    public class ToyGenerator : DataGeneratorAbstract
    {
        private const int MinLength = 4;
        private const int MaxLength = 10;
        private const int PercentageChangeToReturnNull = 20;

        public ToyGenerator(IToyStoreContext toyStoreContext, int seedDataCount, ILogger logger)
            : base(toyStoreContext, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var toy = new Toy()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinLength, MaxLength),
                    Type = this.GetRandomStringOrNull(MinLength, MaxLength),
                    Price = (decimal)Math.Round(RandomDataGenerator.Instance.GetRandomDouble() * 100, 2),
                    Color = RandomDataGenerator.Instance.GetRandomString(MinLength, MaxLength),
                    AgeRangeId = this.GetRandomAgeRangeIdFromDatabase(),
                    ManufacturerId = this.GetRandomManufacturerIdFromDatabase(),
                    Categories = this.GetRandomCategoriesFromDatabase()
                };

                this.ToyStoreContext.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreContext.SaveChanges();
                }
            }

            this.ToyStoreContext.SaveChanges();
            this.Logger.Log(Environment.NewLine);
        }

        private string GetRandomStringOrNull(int minLength, int maxLength)
        {
            if (RandomDataGenerator.Instance.GetChance(PercentageChangeToReturnNull))
            {
                return null;
            }

            var randomString = RandomDataGenerator.Instance.GetRandomString(minLength, maxLength);
            return randomString;
        }

        private int? GetRandomAgeRangeIdFromDatabase()
        {
            if (RandomDataGenerator.Instance.GetChance(PercentageChangeToReturnNull))
            {
                return null;
            }

            var ageRanges = this.ToyStoreContext.AgeRanges;
            var numberOfAgeRangesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, ageRanges.Count() - 1);

            var randomAgeRangeId = ageRanges.OrderBy(a => a.AgeRangeId)
                                            .Skip(numberOfAgeRangesToSkip)
                                            .Select(a => a.AgeRangeId)
                                            .First();
            return randomAgeRangeId;
        }

        private int GetRandomManufacturerIdFromDatabase()
        {
            var manufacturers = this.ToyStoreContext.Manufacturers;
            var numberOfManufacturersToSkip = RandomDataGenerator.Instance.GetRandomInt(0, manufacturers.Count() - 1);

            var randomManufacturerId = manufacturers.OrderBy(m => m.ManufacturerId)
                                                    .Skip(numberOfManufacturersToSkip)
                                                    .Select(a => a.ManufacturerId)
                                                    .First();
            return randomManufacturerId;
        }

        private ICollection<Category> GetRandomCategoriesFromDatabase()
        {
            var categories = this.ToyStoreContext.Categories;

            var categoriesToTake = RandomDataGenerator.Instance.GetRandomInt(0, 3);
            var numberOfCategoriesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, categories.Count() - categoriesToTake - 1);

            var selectedCategories = categories.OrderBy(c => c.CategoryId)
                                               .Skip(numberOfCategoriesToSkip)
                                               .Take(categoriesToTake)
                                               .ToList();
            return selectedCategories;
        }
    }
}