/*
 * 9. Write a program to traverse given directory and write to a XML
 * file its contents together with all subdirectories and files.
 * Use tags <file> and <dir> with appropriate attributes. 
 * For the generation of the XML document use the class XmlWriter.
 */

namespace ProcessingXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class TraverseDirectory
    {
        private const string DirectoryToTraverse = @"C:/Program Files";

        internal static void Main()
        {
            Console.Write("Loading...");
            BuildXmlDirectoryTree();
            Console.Write("\r");
        }
 
        private static void BuildXmlDirectoryTree()
        {
            var xmlTextWriter = new XmlTextWriter("../../directory.xml", Encoding.UTF8);
            var startupDirectory = new DirectoryInfo(DirectoryToTraverse);

            using (xmlTextWriter)
            {
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.IndentChar = '\t';
                xmlTextWriter.Indentation = 1;
                xmlTextWriter.WriteStartElement("directories");
                BuildXmlForDirectoryRecursively(xmlTextWriter, startupDirectory);
                xmlTextWriter.WriteEndDocument();
            }
        }

        private static void BuildXmlForDirectoryRecursively(XmlTextWriter writer, DirectoryInfo dirInfo)
        {
            if (!dirInfo.GetFiles().Any() && !dirInfo.GetDirectories().Any())
            {
                return;              
            }

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", dirInfo.Name);

            foreach (var file in dirInfo.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var dir in dirInfo.GetDirectories())
            {
                BuildXmlForDirectoryRecursively(writer, dir);
            }

            writer.WriteEndElement();
        }
    }
}