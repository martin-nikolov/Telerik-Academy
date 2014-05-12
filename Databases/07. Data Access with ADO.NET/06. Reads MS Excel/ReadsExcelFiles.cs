/*
 * 6. Create an Excel file with 2 columns: name and score
 * Write a program that reads your MS Excel file through the
 * OLE DB data provider and displays the name and score row by row.
 */

using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using DatabaseConnections;

class ReadsExcelFiles
{
    static void Main()
    {
        var excelConnection = new OleDbConnection(Settings.Default.excelConnection);
        excelConnection.Open();

        DataTable excelSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

        OleDbCommand excelCommand = new OleDbCommand(@"SELECT *
                                                           FROM [" + sheetName + "]", excelConnection);

        using (excelConnection)
        {
            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(excelCommand))
            {
                DataSet dataSet = new DataSet();
                oleDbDataAdapter.Fill(dataSet);

                using (DataTableReader reader = dataSet.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        var fullName = reader["Name"];
                        var score = reader["Score"];

                        Console.WriteLine(fullName + " -> " + score);
                    }
                }
            }
        }
    }
}