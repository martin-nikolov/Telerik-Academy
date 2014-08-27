/*
 * 6. Create a database called NorthwindTwin with the same structure as 
 * Northwind using the features from DbContext. Find for the API for
 * schema generation in MSDN or in Google.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class DatabaseCloning
    {
        public static void Main()
        {
            // The connection string in App.config is changed

            Console.Write("Loading...");

            using (var northwindEntities = new NorthwindEntities())
            {
                northwindEntities.Database.CreateIfNotExists();
                Console.WriteLine("\rNumbers of customers: " + northwindEntities.Customers.Count());
            }
        }
    }
}