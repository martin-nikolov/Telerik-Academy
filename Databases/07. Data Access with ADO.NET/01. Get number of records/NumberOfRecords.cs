/*
 * 1. Write a program that retrieves from the Northwind sample 
 * database in MS SQL Server the number of rows in the Categories table.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class NumberOfRecords
    {
        public static void Main()
        {
            GetNumberOfCategories();
        }
 
        private static void GetNumberOfCategories()
        {
            using (var dbConnection = new SqlConnection(Settings.Default.DbConnection))
            {
                dbConnection.Open();
                SqlCommand sqlCommand = GetSqlCommand(dbConnection);
                
                int recordsCount = (int)sqlCommand.ExecuteScalar();
                Console.WriteLine("Total records: {0}", recordsCount);
            }
        }
 
        private static SqlCommand GetSqlCommand(SqlConnection sqlConnection)
        {
            // COUNT(CategoryId) is faster than COUNT(*) -> CategoryId is NOT NULL
            SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(CategoryId) 
                                                     FROM Categories", sqlConnection);
            return sqlCommand;
        }
    }
}