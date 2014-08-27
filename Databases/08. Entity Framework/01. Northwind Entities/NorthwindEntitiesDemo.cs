/*
 * 1. Using the Visual Studio Entity Framework designer 
 * create a DbContext for the Northwind database
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class NorthwindEntitiesDemo
    {
        public static void Main()
        {
            Console.Write("Loading...");

            using (var northwindEntities = new NorthwindEntities())
            {
                var contactNames = northwindEntities.Customers.Select(c => c.ContactName); // Projection
                Console.WriteLine("\r" + string.Join(Environment.NewLine, contactNames));
            }
        }
    }
}