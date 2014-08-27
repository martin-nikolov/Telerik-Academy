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

    public class ConcurrencySimulation
    {
        public static void Main()
        {
            Console.Write("Loading...");

            StartFirstConnection();
            PrintActualResult();
        }
 
        private static void StartFirstConnection()
        {
            using (var firstConnection = new NorthwindEntities())
            {
                PrintWhatFirstUserSees(firstConnection);
                StartSecondConnection(firstConnection);
                PrintWhatFirstUserSeesAfterChanges(firstConnection);
            }
        }

        private static void StartSecondConnection(NorthwindEntities firstConnection)
        {
            using (var secondConnection = new NorthwindEntities())
            {
                PrintWhatSecondUserSees(secondConnection);
                firstConnection.SaveChanges();
                secondConnection.SaveChanges();
                PrintWhatSecondUserSeesAfterChanges(secondConnection);
            }
        }
 
        private static void PrintWhatFirstUserSees(NorthwindEntities firstConnection)
        {
            Console.WriteLine("\rUser1 see: {0}\n", firstConnection.Employees.First().FirstName);
            var firstEmployee1 = firstConnection.Employees.First();
            firstEmployee1.FirstName = "1";
            Console.WriteLine("User1 changes the name with new value: {0}\n", firstConnection.Employees.First().FirstName);
        }

        private static void PrintWhatFirstUserSeesAfterChanges(NorthwindEntities firstConnection)
        {
            Console.WriteLine("After all changes:");
            Console.WriteLine("User1 see: {0}\n", firstConnection.Employees.First().FirstName);
        }

        private static void PrintWhatSecondUserSees(NorthwindEntities secondConnection)
        {
            Console.WriteLine("User2 see: {0}\n", secondConnection.Employees.First().FirstName);
            var firstEmployee2 = secondConnection.Employees.First();
            firstEmployee2.FirstName = "2";
            Console.WriteLine("User2 changes the name with new value: {0}\n", secondConnection.Employees.First().FirstName);
        }

        private static void PrintWhatSecondUserSeesAfterChanges(NorthwindEntities secondConnection)
        {
            Console.WriteLine("After all changes:");
            Console.WriteLine("User2 see: {0}\n", secondConnection.Employees.First().FirstName);
        }

        private static void PrintActualResult()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                Console.WriteLine("Actual result: {0}\n", northwindEntities.Employees.First().FirstName);
            }
        }
    }
}