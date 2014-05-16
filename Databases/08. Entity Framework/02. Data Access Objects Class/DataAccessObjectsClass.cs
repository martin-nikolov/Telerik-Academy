/*
 * 2. Create a DAO class with static methods which provide functionality
 * for inserting, modifying and deleting customers. Write a testing class.
 */

namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Models;

    public static class DataAccessObjectsClass
    {
        public static int InsertCustomer(
            string customerId,
            string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var affectedRows = 0;

            var entity = new Customer()
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = companyName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(entity);
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
                affectedRows = dbContext.Database.ExecuteSqlCommand(@"DELETE FROM Customers
                                                                      WHERE CustomerID = {0}", new object[]
                                                                      {
                                                                          customerId
                                                                      });
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
            
            var sqlCommand = @"SELECT *
                        FROM Customers c
                        JOIN Orders o
                            ON c.CustomerID = o.CustomerID
                        WHERE DATEPART(YEAR, o.OrderDate) = {0} 
                                AND o.ShipCountry = {1}";
            
            var orderDateYear = 1997;
            var shipCountry = "Canada";
            
            using (var dbContext = new NorthwindEntities())
            {
                entities = dbContext.Database.SqlQuery<Customer>(sqlCommand, new object[]
                {
                    orderDateYear,
                    shipCountry
                }).ToList();
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