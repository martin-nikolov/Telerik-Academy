/*
 * 8. Write a program, which (using XmlReader and XmlWriter) reads the 
 * file catalog.xml and creates the file album.xml, in which stores 
 * in appropriate way the names of all albums and their authors.
 */

namespace ProcessingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using ProcessingXml.Models;

    public class ExtractAlbumsFromXml
    {
        internal static void Main()
        {
            var bandsByName = new Dictionary<string, Band>();

            ReadXmlDocument(bandsByName);
            CreateXmlDocument(bandsByName);
            PrintBandInformation(bandsByName);
        }
    
        private static void ReadXmlDocument(IDictionary<string, Band> bandsByName)
        {
            using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        var album = CreateAlbum(reader);
                        ReadBandName(reader, bandsByName, album);

                        ReadAuthors(reader, album);
                    }
                }
            }
        }

        private static void CreateXmlDocument(IDictionary<string, Band> bandsByName)
        {
            string fileName = "../../album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                foreach (var band in bandsByName)
                {
                    foreach (var album in band.Value.Albums)
                    {
                        WriteBook(writer, album.Name, string.Join(", ", album.Authors));
                    }
                }
                writer.WriteEndDocument();
            }

            Console.WriteLine("Document {0} created.\n", fileName);
        }
 
        private static Album CreateAlbum(XmlReader reader)
        {
            var albumName = reader.ReadElementContentAsString();
            var album = new Album()
            {
                Name = albumName
            };
            return album;
        }
 
        private static void ReadBandName(XmlReader reader, IDictionary<string, Band> bandsByName, Album album)
        {
            reader.ReadToFollowing("band");
            var bandName = reader.ReadElementContentAsString().Trim();
            if (!bandsByName.ContainsKey(bandName))
            {
                bandsByName[bandName] = new Band()
                {
                    Name = bandName
                };
            }
            bandsByName[bandName].Albums.Add(album);
        }
 
        private static void ReadAuthors(XmlReader reader, Album album)
        {
            reader.ReadToFollowing("artists");
            if (reader.ReadToDescendant("artist"))
            {
                do
                {
                    var artistName = reader.ReadElementContentAsString();
                    album.Authors.Add(artistName);
                }
                while (reader.ReadToNextSibling("artist"));
            }
        }

        private static void WriteBook(XmlWriter writer, string title, string authors)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("title", title);
            writer.WriteElementString("authors", authors);
            writer.WriteEndElement();
        }

        private static void PrintBandInformation(IDictionary<string, Band> bandsByName)
        {
            foreach (var band in bandsByName)
            {
                Console.WriteLine("Band: {0}", band.Key);
                Console.WriteLine("   Albums:");

                foreach (var album in band.Value.Albums)
                {
                    Console.WriteLine("     - {0} | Authors: {1}", album.Name, string.Join(", ", album.Authors));
                }

                Console.WriteLine();
            }
        }
    }
}