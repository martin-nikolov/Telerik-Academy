/*
 * 4. Implement previous by using native SQL query 
 * and executing it through the DbContext.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;

    public class CustomersWithSpecificOrdersSql
    {
        public static void Main()
        {
            foreach (var customer in DataAccessObjectsClass.Customers_With_Orders_In_1997_Shipped_To_Canada_Sql_View())
            {
                Console.WriteLine(customer.CustomerID);
            }
        }
    }
}