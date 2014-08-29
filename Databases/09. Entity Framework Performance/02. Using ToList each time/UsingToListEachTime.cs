/*
 * 2. Using Entity Framework write a query that selects all employees 
 * from the Telerik Academy database, then invokes ToList(), then selects
 * their addresses, then invokes ToList(), then selects their towns,
 * then invokes ToList() and finally checks whether the town is "Sofia".
 * Rewrite the same in more optimized way and compare the performance.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using TelerikAcademy.Models;

    public class UsingToListEachTime
    {
        public static void Main()
        {
            UsingToListEachTimeTest();
            UsingToListOnceTest();
        }

        private static void UsingToListEachTimeTest()
        {
            using (var dbContext = new TelerikAcademyEntities())
            {
                var employees = dbContext.Employees
                                         .ToList()
                                         .Select(e => e.Address)
                                         .ToList()
                                         .Select(a => a.Town)
                                         .ToList()
                                         .Where(t => t.Name == "Sofia")
                                         .ToList();

                Console.WriteLine("Records: " + employees.Count);
            }
        }

        private static void UsingToListOnceTest()
        {
            using (var dbContext = new TelerikAcademyEntities())
            {
                var employees = dbContext.Employees
                                         .Select(e => e.Address)
                                         .Select(a => a.Town)
                                         .Where(t => t.Name == "Sofia")
                                         .ToList();

                Console.WriteLine("Records: " + employees.Count);
            }
        }
    }
}