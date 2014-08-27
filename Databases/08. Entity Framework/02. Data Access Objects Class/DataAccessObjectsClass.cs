/*
 * 2. Create a DAO class with static methods which provide functionality
 * for inserting, modifying and deleting customers. 
 * Write a testing class.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Models;

    public static class DataAccessObjectsClass
    {
        public static int InsertCustomer(Customer customer)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        public static int ModifyCustomerCompanyName(string customerId, string newCompanyName)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomer = dbContext.Customers.Find(customerId);
                targetCustomer.CompanyName = newCompanyName;
                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        public static int DeleteCustomer(string customerId)
        {
            var affectedRows = 0;

            using (var dbContext = new NorthwindEntities())
            {
                var customersToDelete = dbContext.Customers.Where(c => c.CustomerID == customerId);

                if (customersToDelete.Count() > 0)
                {
                    foreach (var customer in customersToDelete)
                    {
                        dbContext.Customers.Remove(customer);
                    }
                }

                affectedRows = dbContext.SaveChanges();
            }

            return affectedRows;
        }

        #region [Views]
        
        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <returns>Enumerated collection</returns>
        public static IEnumerable<Customer> Customers_With_Orders_In_1997_Shipped_To_Canada_View()
        {
            var entities = new List<Customer>();
            
            var orderDateYear = 1997;
            var shipCountry = "Canada";
            
            using (var dbContext = new NorthwindEntities())
            {
                entities = (from customer in dbContext.Customers
                            join order in dbContext.Orders on customer.CustomerID equals order.CustomerID
                            where order.OrderDate.Value.Year == orderDateYear && order.ShipCountry == shipCountry
                            select customer).ToList();
            }
            
            return entities;
        }
        
        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <returns>Enumerated collection</returns>
        public static IEnumerable<Customer> Customers_With_Orders_In_1997_Shipped_To_Canada_Sql_View()
        {
            var entities = new List<Customer>();

            var orderDateYear = 1997;
            var shipCountry = "Canada";
            
            using (var dbContext = new NorthwindEntities())
            {
                entities = (from customer in dbContext.Customers
                            join order in dbContext.Orders on customer.CustomerID equals order.CustomerID
                            where order.OrderDate.Value.Year == orderDateYear && order.ShipCountry == shipCountry
                            select customer).ToList();
            }
            
            return entities;
        }
        
        /// <summary>
        /// Finds all the sales by specified region and period (start/end dates).
        /// </summary>
        /// <returns>Enumerated collection</returns>
        public static IEnumerable<Order> Sales_By_Specified_Region_And_Date_Period_View(
            string region,
            DateTime? startDate,
            DateTime? endDate)
        {
            var entities = new List<Order>();
            
            using (var dbContext = new NorthwindEntities())
            {
                entities = (from order in dbContext.Orders
                            where order.ShipRegion == region &&
                                  order.OrderDate >= startDate &&
                                  order.OrderDate <= endDate
                            select order).ToList();
            }
            
            return entities;
        }
        
        #endregion
    }
}