/*
 * 1. Write a program that retrieves from the Northwind sample 
 * database in MS SQL Server the number of rows in the Categories table.
 */

using System;
using System.Data.SqlClient;
using System.Linq;
using DatabaseConnections;

class NumberOfRecords
{
    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        // COUNT(CategoryId) is faster than COUNT(*) -> CategoryId is NOT NULL
        SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(CategoryId) 
                                                 FROM Categories", dbConnection); 

        using (dbConnection)
        {
            int recordsCount = (int)sqlCommand.ExecuteScalar();

            Console.WriteLine("Total records: {0}", recordsCount);
        }
    }
}