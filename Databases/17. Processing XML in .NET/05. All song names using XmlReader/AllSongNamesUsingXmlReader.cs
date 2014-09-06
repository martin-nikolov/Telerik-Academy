/*
 * 5. Write a program, which using XmlReader extracts all
 * song titles from catalog.xml.
 */

namespace ProcessingXml
{
    using System;
    using System.Linq;
    using System.Xml;

    public class AllSongNamesUsingXmlReader
    {
        internal static void Main()
        {
            Console.WriteLine("All song titles:\n");

            using (XmlReader reader = XmlReader.Create("../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
}