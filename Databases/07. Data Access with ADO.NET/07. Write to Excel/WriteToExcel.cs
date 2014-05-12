/*
 * 7. Implement appending new rows to the Excel file.
 */

using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using DatabaseConnections;

class WriteToExcel
{
    static void Main()
    {
        var excelConnection = new OleDbConnection(Settings.Default.excelConnection);
        excelConnection.Open();

        DataTable excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

        var name = "Peter Ivanov";
        var age = 25;

        OleDbCommand excelCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@name, @age)", excelConnection);

        excelCommand.Parameters.AddWithValue("@name", name);
        excelCommand.Parameters.AddWithValue("@age", age);

        using (excelConnection)
        {
            for (int i = 0; i < 10; i++)
            {
                var queryResult = excelCommand.ExecuteNonQuery();

                Console.WriteLine("({0} row(s) affected)", queryResult); 
            }
        }
    }
}