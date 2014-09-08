namespace Company.DataGenerators
{
    using System;
    using System.Linq;
    using Company.Common;
    using Company.Data;
    using Company.DataGenerators.Abstracts;
    using Company.Models;

    public class ReportGenerator : DataGeneratorAbstract
    {
        private const int LowerBound = 25;
        private const int UpperBound = 75;

        public ReportGenerator(CompanyDbContext companyDbContext, int seedDataCount)
            : base(companyDbContext, seedDataCount)
        {
        }

        public override void Seed()
        {
            if (this.CompanyDbContext.Reports.Any())
            {
                return;
            }

            var employees = this.CompanyDbContext.Employees
                                .ToList();

            var generatedReportsCount = 0;

            while (generatedReportsCount < this.SeedDataCount)
            {
                foreach (var employee in employees)
                {
                    var numberOfReportsToGenerate = RandomDataGenerator.Instance.GetRandomInt(LowerBound, UpperBound);

                    for (int i = 0; i < numberOfReportsToGenerate && generatedReportsCount <= this.SeedDataCount; i++, generatedReportsCount++)
                    {
                        var randomStartDays = RandomDataGenerator.Instance.GetRandomInt(-5 * 365, 5 * 365);
                        var randomDate = DateTime.Now.AddDays(randomStartDays);

                        this.CompanyDbContext.Reports.Add(new Report()
                        {
                            EmployeeId = employee.EmployeeId,
                            Time = randomDate
                        });
                    }

                    if (generatedReportsCount % 100 == 0)
                    {
                        Console.Write(".");
                        this.CompanyDbContext.SaveChanges();
                    }
                }
            }

            this.CompanyDbContext.SaveChanges();
        }
    }
}