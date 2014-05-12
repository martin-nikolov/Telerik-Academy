/*
 * 4. Write a method that adds a new product in the products 
 * table in the Northwind database. Use a parameterized SQL command.
 */

using System;
using System.Data.SqlClient;
using System.Linq;
using DatabaseConnections;

class InsertNewProduct
{
    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        var productName = "Nescafe Coffee";
        var supplierId = 22;
        var categoryId = 1;
        var quantityPerUnit = "16 - 500 g tins";
        var unitPrice = 46.0d;
        var unitsInStock = 1000;
        var unitsInOrder = 500;
        var reorderLevel = 30;
        var discontinued = 0;

        SqlCommand sqlCommand =
            new SqlCommand(@"INSERT INTO Products
                             VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, 
                                     @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)", dbConnection);

        sqlCommand.Parameters.AddWithValue("@productName", productName);
        sqlCommand.Parameters.AddWithValue("@supplierId", supplierId);
        sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
        sqlCommand.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
        sqlCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
        sqlCommand.Parameters.AddWithValue("@unitsInStock", unitsInStock);
        sqlCommand.Parameters.AddWithValue("@unitsInOrder", unitsInOrder);
        sqlCommand.Parameters.AddWithValue("@reorderLevel", reorderLevel);
        sqlCommand.Parameters.AddWithValue("@discontinued", discontinued);

        using (dbConnection)
        {
            var queryResult = sqlCommand.ExecuteNonQuery();

            Console.WriteLine("({0} row(s) affected)", queryResult); 
        }
    }
}