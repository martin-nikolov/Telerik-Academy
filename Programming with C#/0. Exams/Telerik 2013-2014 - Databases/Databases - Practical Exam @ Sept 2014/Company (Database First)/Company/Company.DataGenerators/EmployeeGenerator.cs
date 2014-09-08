namespace Company.DataGenerators
{
    using System;
    using System.Linq;
    using Company.Common;
    using Company.Data;
    using Company.DataGenerators.Abstracts;
    using Company.Models;

    public class EmployeeGenerator : DataGeneratorAbstract
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 20;
        private const int PercentageOfEmployeesWithoutManager = 5;

        public EmployeeGenerator(CompanyDbContext companyDbContext, int seedDataCount)
            : base(companyDbContext, seedDataCount)
        {
        }

        public override void Seed()
        {
            if (this.CompanyDbContext.Employees.Any())
            {
                return;
            }

            var numberOfEmployeesWithoutManager = (this.SeedDataCount / 100) * PercentageOfEmployeesWithoutManager;
            var numberOfEmployeesWithManager = this.SeedDataCount - numberOfEmployeesWithoutManager;

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var employee = new Employee()
                {
                    FirstName = RandomDataGenerator.Instance.GetRandomString(MinNameLength, MaxNameLength),
                    LastName = RandomDataGenerator.Instance.GetRandomString(MinNameLength, MaxNameLength),
                    DepartmentId = this.GetRandomDepartmentId(),
                    YearSalary = RandomDataGenerator.Instance.GetRandomInt(50000, 250000) //(decimal)RandomDataGenerator.Instance.GetRandomDouble() * RandomDataGenerator.Instance.GetRandomInt(10000, 50000),
                };

                this.CompanyDbContext.Employees.Add(employee);
            
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.CompanyDbContext.SaveChanges();
                }
            }

            this.CompanyDbContext.SaveChanges();
            this.SetManagerIdsToEmployees(numberOfEmployeesWithManager);
        }
 
        private void SetManagerIdsToEmployees(int numberOfEmployeesWithManager)
        {
            var allEmployees = this.CompanyDbContext.Employees.ToList();

            for (int i = 0; i < numberOfEmployeesWithManager; i++)
            {
                allEmployees[i].ManagerId = this.GetRandomManagerId();
                this.CompanyDbContext.Entry(allEmployees[i]).State = System.Data.Entity.EntityState.Modified;

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.CompanyDbContext.SaveChanges();
                }
            }

            this.CompanyDbContext.SaveChanges();
        }

        private int GetRandomDepartmentId()
        {
            var totalDepartments = this.CompanyDbContext.Departments.Count();

            var numberOfDepartmentsToSkip = RandomDataGenerator.Instance.GetRandomInt(0, totalDepartments - 1);
            var randomDepartmentId = this.CompanyDbContext.Departments
                                         .OrderBy(d => d.DepartmentId)
                                         .Skip(numberOfDepartmentsToSkip)
                                         .Select(d => d.DepartmentId)
                                         .First();
            return randomDepartmentId;
        }

        private int GetRandomManagerId()
        {
            var totalManagers = this.CompanyDbContext.Employees.Count();

            var numberManagersToSkip = RandomDataGenerator.Instance.GetRandomInt(0, totalManagers - 1);
            var randomEmployee = this.CompanyDbContext.Employees
                                     .OrderBy(e => e.EmployeeId)
                                     .Skip(numberManagersToSkip)
                                     .Select(d => new
                                     {
                                         EmployeeId = d.EmployeeId,
                                         ManagerId = d.ManagerId
                                     })
                                     .First();

            if (randomEmployee.ManagerId.HasValue)
            {
                return randomEmployee.ManagerId.Value;
            }

            return randomEmployee.EmployeeId;
        }
    }
}