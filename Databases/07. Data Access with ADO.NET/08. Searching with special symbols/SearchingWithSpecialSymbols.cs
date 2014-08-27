/*
 * 8. Write a program that reads a string from the console and 
 * finds all products that contain this string. Ensure you handle
 * correctly characters like ', %, ", \ and _.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class SearchingWithSpecialSymbols
    {
        public static void Main()
        {
            Console.Write("Enter a search string: ");
            var pattern = Console.ReadLine();

            SearchProductNameByPattern(pattern);
        }
 
        private static void SearchProductNameByPattern(string pattern)
        {
            using (var dbConnection = new SqlConnection(Settings.Default.DbConnection))
            {
                dbConnection.Open();
                SqlCommand sqlCommand = GetSearchByPatternSqlCommand(dbConnection, pattern);

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
 
        private static SqlCommand GetSearchByPatternSqlCommand(SqlConnection sqlConnection, string pattern)
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT ProductName
                                                     FROM Products
                                                     WHERE CHARINDEX(@pattern, ProductName) > 0", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@pattern", pattern);
            return sqlCommand;
        }
    }
}