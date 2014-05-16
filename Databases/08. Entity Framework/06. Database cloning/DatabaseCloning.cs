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

    class DatabaseCloning
    {
        static void Main()
        {
            // The connection string in App.config is changed

            var northwindEntities = new NorthwindEntities();
            northwindEntities.Database.CreateIfNotExists();
        }
    }
}