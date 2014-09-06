namespace ToyStore.DataGenerators
{
    using System;
    using System.Linq;
    using ToyStore.Data.Contracts;
    using ToyStore.Data.Models;
    using ToyStore.DataGenerators.Abstracts;
    using ToyStore.DataGenerators.Contracts;

    public class AgeRangeGenerator : DataGeneratorAbstract
    {
        public AgeRangeGenerator(IToyStoreContext toyStoreContext, int seedDataCount, ILogger logger)
            : base(toyStoreContext, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            var lowerBound = 1;
            var upperBound = 5;
            var minAge = 1;

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var ageRange = new AgeRange()
                {
                    MinAge = minAge,
                    MaxAge = upperBound
                };

                this.ToyStoreContext.AgeRanges.Add(ageRange);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreContext.SaveChanges();
                }

                this.ChangeAgeValue(ref minAge, ref lowerBound, ref upperBound);
            }

            this.ToyStoreContext.SaveChanges();
            this.Logger.Log(Environment.NewLine);
        }
 
        private void ChangeAgeValue(ref int minAge, ref int lowerBound, ref int upperBound)
        {
            if (minAge++ + 2 >= upperBound)
            {
                lowerBound++;
                upperBound += lowerBound - 2;
                minAge = lowerBound;
            }
        }
    }
}