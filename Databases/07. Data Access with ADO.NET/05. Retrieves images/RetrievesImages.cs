/*
 * 5. Write a program that retrieves the images for all categories in
 * the Northwind database and stores them as JPG files in the file system.
 */

namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class RetrievesImages
    {
        private const int OleMetaFilePictStartPosition = 78;

        public static void Main()
        {
            GetImagesFromDatabase();
        }
 
        private static void GetImagesFromDatabase()
        {
            using (var dbConnection = new SqlConnection(Settings.Default.DbConnection))
            {
                dbConnection.Open();
                SqlCommand sqlCommand = GetSqlCommand(dbConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int imageId = 1;

                    while (reader.Read())
                    {
                        var fileBinaryData = (byte[])reader["Picture"];
                        SaveImageWithOleMetaFilePict(imageId.ToString(), fileBinaryData, ".jpg");
                        imageId++;
                    }
                }
            }
        }

        private static void SaveImageWithOleMetaFilePict(string fileName, byte[] imageBinaryData, string extension)
        {
            MemoryStream memoryStream =
                new MemoryStream(imageBinaryData, OleMetaFilePictStartPosition, imageBinaryData.Length - OleMetaFilePictStartPosition);

            using (memoryStream)
            {
                using (var image = Image.FromStream(memoryStream))
                {
                    image.Save(fileName + extension);
                }
            }
        }

        private static SqlCommand GetSqlCommand(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(@"SELECT Picture 
                                                     FROM Categories", sqlConnection);
            return sqlCommand;
        }
    }
}