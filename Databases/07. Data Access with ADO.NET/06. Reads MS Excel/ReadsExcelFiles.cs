/*
 * 6. Create an Excel file with 2 columns: name and score
 * Write a program that reads your MS Excel file through the
 * OLE DB data provider and displays the name and score row by row.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;

    public class ReadsExcelFiles
    {
        public static void Main()
        {
            ReadExcelData();
        }
 
        private static void ReadExcelData()
        {
            using (var excelConnection = new OleDbConnection(Settings.Default.excelConnection))
            {
                excelConnection.Open();
                string sheetName = GetSheetName(excelConnection);
                OleDbCommand excelCommand = GetOleDbCommand(sheetName, excelConnection);

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
     
        private static string GetSheetName(OleDbConnection oleDbConnection)
        {
            DataTable excelSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
            return sheetName;
        }

        private static OleDbCommand GetOleDbCommand(string sheetName, OleDbConnection excelConnection)
        {
            OleDbCommand oleDbCommand = new OleDbCommand(@"SELECT *
                                                           FROM [" + sheetName + "]", excelConnection);
            return oleDbCommand;
        }
    }
}