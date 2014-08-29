/*
 * 1. Using Entity Framework write a SQL query to select all employees
 * from the Telerik Academy database and later print their name, 
 * department and town. Try the both variants: with and without .Include(…).
 * Compare the number of executed SQL statements and the performance.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using TelerikAcademy.Models;

    public class UsingIncludeStatement
    {
        public static void Main()
        {
            SelectEmployeesUsingIncludeStatement();
            SelectEmployeedWithoutUsingIncludeStatement();
        }
    
        private static void SelectEmployeesUsingIncludeStatement()
        {
            using (var dbContext = new TelerikAcademyEntities())
            {
                foreach (var employee in dbContext.Employees.Include("Address.Town").Include("Department"))
                {
                    Console.WriteLine("{{ Name: {0}, Department: {1}, Town: {2} }}",
                        employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }

        private static void SelectEmployeedWithoutUsingIncludeStatement()
        {
            using (var dbContext = new TelerikAcademyEntities())
            {
                foreach (var employee in dbContext.Employees)
                {
                    Console.WriteLine("{{ Name: {0}, Department: {1}, Town: {2} }}",
                        employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }
    }
}