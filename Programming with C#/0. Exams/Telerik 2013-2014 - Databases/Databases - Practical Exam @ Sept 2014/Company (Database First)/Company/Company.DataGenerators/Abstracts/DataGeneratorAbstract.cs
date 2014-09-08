namespace Company.DataGenerators.Abstracts
{
    using System;
    using System.Linq;
    using Company.Data;
    using Company.DataGenerators.Contracts;

    public abstract class DataGeneratorAbstract : IDataGenerator
    {
        private CompanyDbContext companyDbContext;
        private int seedDataCount;

        public DataGeneratorAbstract(CompanyDbContext companyDbContext, int seedDataCount)
        {
            this.companyDbContext = companyDbContext;
            this.seedDataCount = seedDataCount;
        }

        protected int SeedDataCount
        {
            get
            {
                return this.seedDataCount;
            }
            set
            {
                this.seedDataCount = value;
            }
        }

        protected CompanyDbContext CompanyDbContext
        {
            get
            {
                return this.companyDbContext;
            }
            set
            {
                this.companyDbContext = value;
            }
        }

        public abstract void Seed();
    }
}