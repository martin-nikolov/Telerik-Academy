/*
 * 7. Try to open two different data contexts and perform concurrent 
 * changes on the same records. What will happen at SaveChanges()?
 * How to deal with it?
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    class ConcurrencySimulation
    {
        static void Main()
        {
            using (var firstConnection = new NorthwindEntities())
            {
                Console.WriteLine("User1 see: {0}\n", firstConnection.Employees.First().FirstName);
                var firstEmployee1 = firstConnection.Employees.First();
                firstEmployee1.FirstName = "1";
                Console.WriteLine("User1 changes the name with new value: {0}\n", firstConnection.Employees.First().FirstName);

                using (var secondConnection = new NorthwindEntities())
                {
                    Console.WriteLine("User2 see: {0}\n", secondConnection.Employees.First().FirstName);
                    var firstEmployee2 = secondConnection.Employees.First();
                    firstEmployee2.FirstName = "2";
                    Console.WriteLine("User2 changes the name with new value: {0}\n", secondConnection.Employees.First().FirstName);

                    firstConnection.SaveChanges();
                    secondConnection.SaveChanges();
                }
                
                Console.WriteLine("After all changes:");
                Console.WriteLine("User1 see: {0}\n", firstConnection.Employees.First().FirstName);
            }
          
            using (var northwindEntities = new NorthwindEntities())
            {
                Console.WriteLine("Actual result: {0}\n", northwindEntities.Employees.First().FirstName);
            }
        }
    }
}