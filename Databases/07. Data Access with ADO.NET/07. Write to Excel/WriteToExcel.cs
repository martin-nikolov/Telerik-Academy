/*
 * 7. Implement appending new rows to the Excel file.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    public class WriteToExcel
    {
        public static void Main()
        {
            InsertRecordsToExcel();
        }
 
        private static void InsertRecordsToExcel(int numberOfRecordsToInsert = 10)
        {
            using (var excelConnection = new OleDbConnection(Settings.Default.excelConnection))
            {
                excelConnection.Open();
                string sheetName = GetSheetName(excelConnection);
                OleDbCommand excelCommand = GetInsertOleDbCommand(excelConnection, sheetName);

                for (int i = 0; i < numberOfRecordsToInsert; i++)
                {
                    var queryResult = excelCommand.ExecuteNonQuery();
                    Console.WriteLine("({0} row(s) affected)", queryResult); 
                }
            }
        }
 
        private static string GetSheetName(OleDbConnection oleDbCommand)
        {
            DataTable excelSchema = oleDbCommand.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
            return sheetName;
        }
 
        private static OleDbCommand GetInsertOleDbCommand(OleDbConnection oleDbConnection, string sheetName)
        {
            var name = "Peter Ivanov";
            var age = 25;

            OleDbCommand excelCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@name, @age)", oleDbConnection);
            
            excelCommand.Parameters.AddWithValue("@name", name);
            excelCommand.Parameters.AddWithValue("@age", age);

            return excelCommand;
        }
    }
}