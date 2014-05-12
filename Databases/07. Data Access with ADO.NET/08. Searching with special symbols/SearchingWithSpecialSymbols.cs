/*
 * 8. Write a program that reads a string from the console and 
 * finds all products that contain this string. Ensure you handle
 * correctly characters like ', %, ", \ and _.
 */

using System;
using System.Data.SqlClient;
using System.Linq;
using DatabaseConnections;

class SearchingWithSpecialSymbols
{
    static void Main()
    {
        Console.Write("Enter a search string: ");
        var pattern = Console.ReadLine();

        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(@"SELECT ProductName
                                                 FROM Products
                                                 WHERE CHARINDEX(@pattern, ProductName) > 0", dbConnection);

        sqlCommand.Parameters.AddWithValue("@pattern", pattern);

        using (dbConnection)
        {
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var productName = reader["ProductName"];

                    Console.WriteLine(" - " + productName);
                }
            }
        }
    }
}