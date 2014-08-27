/*
 * 3. Write a method that finds all customers who have orders
 * made in 1997 and shipped to Canada.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;

    public class CustomersWithSpecificOrders
    {
        public static void Main()
        {
            foreach (var customer in DataAccessObjectsClass.Customers_With_Orders_In_1997_Shipped_To_Canada_View())
            {
                Console.WriteLine(customer.CustomerID);
            }
        }
    }
}