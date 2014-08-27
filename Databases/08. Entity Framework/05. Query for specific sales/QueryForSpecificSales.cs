/*
 * 5. Write a method that finds all the sales by specified
 * region and period (start / end dates).
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;

    public class QueryForSpecificSales
    {
        public static void Main()
        {
            var region = "SP";
            var startDate = new DateTime(1995, 5, 10);
            var endDate = new DateTime(1996, 12, 4);

            var orders = DataAccessObjectsClass.Sales_By_Specified_Region_And_Date_Period_View(region, startDate, endDate);

            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderID);
            }
        }
    }
}