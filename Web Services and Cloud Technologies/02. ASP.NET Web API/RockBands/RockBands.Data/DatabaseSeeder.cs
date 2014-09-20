namespace RockBands.Data
{
    using System;
    using System.Linq;
    using RockBands.Data.Contracts;

    public class DatabaseSeeder
    {
        private readonly IRockBandsData rockBandsData;

        public DatabaseSeeder(IRockBandsData rockBandsData)
        {
            this.rockBandsData = rockBandsData;
        }

        public void SeedDataToDatabase()
        {
        }
    }
}