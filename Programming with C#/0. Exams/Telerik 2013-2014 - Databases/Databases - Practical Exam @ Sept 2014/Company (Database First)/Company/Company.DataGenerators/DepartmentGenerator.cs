namespace Company.DataGenerators
{
    using System;
    using System.Linq;
    using Company.Common;
    using Company.Data;
    using Company.DataGenerators.Abstracts;
    using Company.Models;

    public class DepartmentGenerator : DataGeneratorAbstract
    {
        private const int MinNameLength = 10;
        private const int MaxNameLength = 50;

        public DepartmentGenerator(CompanyDbContext companyDbContext, int seedDataCount)
            : base(companyDbContext, seedDataCount)
        {
        }

        public override void Seed()
        {
            if (this.CompanyDbContext.Departments.Any())
            {
                return;
            }

            var uniqueDepartmentNames = RandomDataGenerator.Instance.GetUniqueStringsCollection(MinNameLength, MaxNameLength, this.SeedDataCount);

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var department = new Department()
                {
                    Name = uniqueDepartmentNames[i]
                };

                this.CompanyDbContext.Departments.Add(department);

                if (i % 100 == 0)
                {
                    this.CompanyDbContext.SaveChanges();
                }
            }

            this.CompanyDbContext.SaveChanges();
        }
    }
}