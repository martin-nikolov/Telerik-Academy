/*
 * 2. Write program that extracts all different artists which 
 * are found in the catalog.xml. For each author you should print
 * the number of albums in the catalogue. Use the DOM parser and a hash-table.
 */

namespace ProcessingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class ParseXmlEntryPoint
    {
        internal static void Main()
        {
            var catalogXml = XElement.Load("../../catalog.xml");

            var artistNames = ExtractAllArtistNames(catalogXml);
            Console.WriteLine("All artists: {0}\n", string.Join(", ", artistNames));

            var bandsAlbums = ExtractNumberOfAlbumsForEachBand(catalogXml);
            foreach (var bandAlbum in bandsAlbums)
            {
                Console.WriteLine("{0}: {1} song(s)", bandAlbum.Key, bandAlbum.Value);
            }
        }

        private static ICollection<string> ExtractAllArtistNames(XElement xmlDocument)
        {
            var artistNames = new HashSet<string>();
            var albumsXml = xmlDocument.Element("albums").Elements("album");

            foreach (var album in albumsXml)
            {
                foreach (var artist in album.Element("artists").Elements("artist"))
                {
                    artistNames.Add(artist.Value);
                }
            }

            return artistNames;
        }

        private static IDictionary<string, int> ExtractNumberOfAlbumsForEachBand(XElement xmlDocument)
        {
            var bandsAlbums = new Dictionary<string, int>();
            var albumsXml = xmlDocument.Element("albums").Elements("album");

            foreach (var album in albumsXml)
            {
                var bandName = album.Element("band").Value;

                if (!bandsAlbums.ContainsKey(bandName))
                {
                    bandsAlbums[bandName] = 0;
                }

                bandsAlbums[bandName]++;
            }

            return bandsAlbums;
        }
    }
}