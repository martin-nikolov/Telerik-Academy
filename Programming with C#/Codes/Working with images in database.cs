using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using DatabaseConnections;

class DatabaseWorkingWithImages
{
    const int OleMetafilepictStartPosition = 78;
    const string SourceImageFileName = @"image.png";
    const string SourceImageToFormat = @".jpg";

    static void Main()
    {
        var dbConnection = new SqlConnection(Settings.Default.DbConnection);
        dbConnection.Open();

        SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO Images ([Image], ImageFormat) 
                                                 VALUES (@image, @imageFormat)", dbConnection);

        byte[] image = ReadBinaryFile(SourceImageFileName);
        string imageFormat = GetImageFormat(SourceImageFileName);
        Console.WriteLine("Loaded image file {0}.", SourceImageFileName);

        using (dbConnection)
        {
            // Insert a image to database
            SqlParameter paramImage = new SqlParameter("@image", SqlDbType.Image);
            paramImage.Value = image;
            sqlCommand.Parameters.Add(paramImage);

            SqlParameter paramImageFormat = new SqlParameter("@imageFormat", SqlDbType.VarChar);
            paramImageFormat.Value = imageFormat;
            sqlCommand.Parameters.Add(paramImageFormat);

            sqlCommand.ExecuteNonQuery();

            // Select and save images from database
            SqlCommand sqlForSelect = new SqlCommand(@"SELECT [Image]
                                                       FROM Images", dbConnection);

            using (SqlDataReader reader = sqlForSelect.ExecuteReader())
            {
                int imageId = 1;

                while (reader.Read())
                {
                    var fileBinaryData = (byte[])reader["Image"];

                    SaveImage(imageId.ToString(), fileBinaryData);

                    imageId++;
                }
            }
        }
    }

    static byte[] ReadBinaryFile(string fileName)
    {
        using (FileStream stream = File.OpenRead(fileName))
        {
            int index = 0;
            int length = (int)stream.Length;
            byte[] buffer = new byte[length];

            while (true)
            {
                int bytesRead = stream.Read(buffer, index, length - index);

                if (bytesRead == 0)
                {
                    break;
                }

                index += bytesRead;
            }

            return buffer;
        }
    }

    static string GetImageFormat(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string imageFormat = fileInfo.Extension.ToLower().Substring(1);

        return imageFormat;
    }

    static void SaveImage(string fileName, byte[] imageBinaryData)
    {
        using (MemoryStream memoryStream = new MemoryStream(imageBinaryData))
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                image.Save(fileName + SourceImageToFormat);
            }
        }
    }

    /// <summary>
    /// Same as method SaveImage(string fileName, byte[] imageBinaryData)
    /// </summary>
    static void WriteBinaryFile(string fileName, byte[] imageBinaryData)
    {
        using (FileStream stream = File.OpenWrite(fileName + SourceImageToFormat))
        {
            stream.Write(imageBinaryData, 0, imageBinaryData.Length);
        }
    }

    static void SaveImageWithOleMetafilepict(string fileName, byte[] imageBinaryData)
    {
        MemoryStream memoryStream =
            new MemoryStream(imageBinaryData, OleMetafilepictStartPosition, imageBinaryData.Length - OleMetafilepictStartPosition);

        using (memoryStream)
        {
            using (Image image = Image.FromStream(memoryStream))
            {
                image.Save(fileName + SourceImageToFormat);
            }
        }
    }
}