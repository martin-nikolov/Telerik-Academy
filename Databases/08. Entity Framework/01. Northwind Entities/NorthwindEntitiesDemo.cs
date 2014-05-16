/*
 * 1. Using the Visual Studio Entity Framework designer 
 * create a DbContext for the Northwind database
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    class NorthwindEntitiesDemo
    {
        static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                // Projection
                var customers = northwindEntities.Customers.Select(c => new
                {
                    ContactName = c.ContactName
                });

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }
    }
}