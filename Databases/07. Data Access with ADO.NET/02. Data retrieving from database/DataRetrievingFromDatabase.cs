/*
 * 2. Write a program that retrieves the name and description
 * of all categories in the Northwind DB.
 */

using System;
using System.Data.SqlClient;
using System.Linq;
using DatabaseConnections;

class DataRetrievingFromDatabase
{
    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(@"SELECT CategoryName, Description
                                                 FROM Categories", dbConnection);
        using (dbConnection)
        {
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Category: {0} -> {1}", reader["CategoryName"], reader["Description"]);
                }
            }
        }
    }
}