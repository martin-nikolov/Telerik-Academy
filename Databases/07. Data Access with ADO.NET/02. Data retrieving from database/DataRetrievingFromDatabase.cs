/*
 * 2. Write a program that retrieves the name and description
 * of all categories in the Northwind DB.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class DataRetrievingFromDatabase
    {
        public static void Main()
        {
            GetCategoriesFromDatabase();
        }
 
        private static void GetCategoriesFromDatabase()
        {
            using (var dbConnection = new SqlConnection(Settings.Default.DbConnection))
            {
                dbConnection.Open();
                SqlCommand sqlCommand = GetSqlCommand(dbConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Category: {0} -> {1}",
                            reader["CategoryName"], reader["Description"]);
                    }
                }
            }
        }
 
        private static SqlCommand GetSqlCommand(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT CategoryName, Description
                                                     FROM Categories", sqlConnection);
            return sqlCommand;
        }
    }
}