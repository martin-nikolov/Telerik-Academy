namespace Company.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Company.Common;
    using Company.Data;
    using Company.DataGenerators.Abstracts;
    using Company.Models;

    public class ProjectGenerator : DataGeneratorAbstract
    {
        private const int MinNumberOfEmployees = 2;
        private const int MaxNumberOfEmployees = 20;

        private const int MinNameLength = 5;
        private const int MaxNameLength = 50;

        public ProjectGenerator(CompanyDbContext companyDbContext, int seedDataCount)
            : base(companyDbContext, seedDataCount)
        {
        }

        public override void Seed()
        {
            if (this.CompanyDbContext.Projects.Any())
            {
                return;
            }
            
            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var project = new Project()
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinNameLength, MaxNameLength)
                };

                this.CompanyDbContext.Projects.Add(project);
                this.AddEmployeesToProject(project);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.CompanyDbContext.SaveChanges();
                }
            }

            this.CompanyDbContext.SaveChanges();
        }
 
        private void AddEmployeesToProject(Project project)
        {
            var randomEmployees = this.GetRandomEmployees();

            foreach (var employee in randomEmployees)
            {
                var randomDateRanges = this.GetRandomDateTimeRanges();

                this.CompanyDbContext.EmployeeProjects.Add(new EmployeeProject()
                {
                    Project = project,
                    EmployeeId = employee.EmployeeId,
                    StartingDate = randomDateRanges[0],
                    EndingDate = randomDateRanges[1]
                });
            }
        }

        private DateTime[] GetRandomDateTimeRanges()
        {
            var randomStartDays = RandomDataGenerator.Instance.GetRandomInt(-5 * 365, 5 * 365);
            var startDate = DateTime.Now.AddDays(randomStartDays);

            var randomEndDays = RandomDataGenerator.Instance.GetRandomInt(0, 5 * 365);
            var endDate = startDate.AddDays(randomEndDays);

            return new DateTime[]
            {
                startDate, endDate
            };
        }

        private ICollection<Employee> GetRandomEmployees()
        {
            var numberOfEmployees = this.CompanyDbContext.Employees.Count();
            var numberOfEmployeesToTake = RandomDataGenerator.Instance.GetRandomInt(MinNumberOfEmployees, MaxNumberOfEmployees);
            var numberOfEmployeesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, numberOfEmployees - numberOfEmployeesToTake - 1);

            var randomEmployees = this.CompanyDbContext.Employees
                                      .OrderBy(e => e.EmployeeId)
                                      .Skip(numberOfEmployeesToSkip)
                                      .Take(numberOfEmployeesToTake);

            return randomEmployees.ToList();
        }
    }
}