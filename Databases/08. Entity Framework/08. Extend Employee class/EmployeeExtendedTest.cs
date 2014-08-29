/*
 * 8. By inheriting the Employee entity class create a class which
 * allows employees to access their corresponding territories as
 * property of type EntitySet<T>.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class EmployeeExtendedTest
    {
        public static void Main()
        {
            // See file -> Northwind.Models -> `Employee.cs
 
            using (var dbContext = new NorthwindEntities())
            {
                foreach (var employee in dbContext.Employees.Include("Territories"))
                {
                    var correspondingTerritories = employee.CorrespondingTerritories.Select(c => c.TerritoryID);
                    var correspondingTerritoriesAsString = string.Join(", ", correspondingTerritories);
                    Console.WriteLine("{0} -> Territory IDs: {1}", employee.FirstName, correspondingTerritoriesAsString);
                }
            }
        }
    }
}