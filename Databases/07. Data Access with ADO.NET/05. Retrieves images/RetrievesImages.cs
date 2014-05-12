/*
 * 5. Write a program that retrieves the images for all categories in
 * the Northwind database and stores them as JPG files in the file system.
 */

using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using DatabaseConnections;

class RetrievesImages
{
    const int OleMetaFilePictStartPosition = 78;

    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(@"SELECT Picture 
                                                 FROM Categories", dbConnection);

        using (dbConnection)
        {
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

    static void SaveImageWithOleMetaFilePict(string fileName, byte[] imageBinaryData, string format)
    {
        MemoryStream memoryStream =
            new MemoryStream(imageBinaryData, OleMetaFilePictStartPosition, imageBinaryData.Length - OleMetaFilePictStartPosition);

        using (memoryStream)
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                image.Save(fileName + format);
            }
        }
    }
}