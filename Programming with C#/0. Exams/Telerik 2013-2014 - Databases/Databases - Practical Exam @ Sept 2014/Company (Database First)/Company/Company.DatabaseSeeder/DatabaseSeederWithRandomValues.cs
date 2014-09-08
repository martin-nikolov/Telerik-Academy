namespace Company.DatabaseSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;
    using Company.DataGenerators;
    using Company.DataGenerators.Contracts;
    using Company.DatabaseSeeder.Contracts;

    public class DatabaseSeederWithRandomValues : ISeeder
    {
        private const int DepartmentsCount = 100;
        private const int EmployeesCount = 5000;
        private const int ProjecsCount = 1000;
        private const int ReportsCount = 250000;

        private readonly CompanyDbContext companyDbContext;

        public DatabaseSeederWithRandomValues(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public void SeedDatabaseWithRandomData()
        {
            var dataGenerators = new List<IDataGenerator>()
            {
                new DepartmentGenerator(this.companyDbContext, DepartmentsCount),
                new EmployeeGenerator(this.companyDbContext, EmployeesCount),
                new ProjectGenerator(this.companyDbContext, ProjecsCount),
                new ReportGenerator(this.companyDbContext, ReportsCount),
            };

            Console.WriteLine("Seed database with random data...");
            
            foreach (var dataGenerator in dataGenerators)
            {
                dataGenerator.Seed();
            }

            Console.WriteLine();
        }
    }
}