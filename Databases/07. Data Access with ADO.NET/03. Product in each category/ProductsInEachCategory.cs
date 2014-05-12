/*
 * 3. Write a program that retrieves from the Northwind database
 * all product categories and the names of the products in each 
 * category. Can you do this with a single SQL query (with table join)?
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DatabaseConnections;

class ProductsInEachCategory
{
    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(@"SELECT c.CategoryName, p.ProductName
                                                 FROM Categories c
                                                 JOIN Products P
                                                    ON c.CategoryID = p.CategoryID
                                                 ORDER BY c.CategoryID", dbConnection);

        var categoryProducts = new Dictionary<string, ISet<string>>();

        using (dbConnection)
        {
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var categoryName = reader["CategoryName"].ToString();
                    var productName = reader["ProductName"].ToString();

                    if (!categoryProducts.ContainsKey(categoryName))
                    {
                        categoryProducts[categoryName] = new HashSet<string>();
                    }

                    categoryProducts[categoryName].Add(productName);
                }
            }
        }

        PrintResult(categoryProducts);
    }
  
    static void PrintResult(IDictionary<string, ISet<string>> categoryProducts)
    {
        foreach (var categories in categoryProducts)
        {
            Console.WriteLine("Category name: {0}", categories.Key);

            foreach (var productName in categories.Value)
            {
                Console.WriteLine(" - {0}", productName);
            }

            Console.WriteLine();
        }
    }
}