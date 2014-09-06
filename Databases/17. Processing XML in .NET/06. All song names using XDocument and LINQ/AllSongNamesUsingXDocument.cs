/*
 * 6. Rewrite the previous task using XDocument and LINQ query.
 */

namespace ProcessingXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class AllSongNamesUsingXDocument
    {
        internal static void Main()
        {
            var catalogXml = XDocument.Load("../../catalog.xml");
            var albumsXml = catalogXml.Element("catalog")
                                      .Element("albums")
                                      .Elements("album");

            var songTitles = from songName in albumsXml.Descendants("title")
                             select new
                             {
                                 Title = songName.Value
                             };

            Console.WriteLine("All song titles:\n");
            foreach (var song in songTitles)
            {
                Console.WriteLine(song.Title);
            }
        }
    }
}