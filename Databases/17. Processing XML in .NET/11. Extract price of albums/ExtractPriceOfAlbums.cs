/*
 * 11. Write a program, which extract from the file catalog.xml the 
 * prices for all albums, published 5 years ago or earlier Use XPath query.
 */

namespace ProcessingXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class ExtractPriceOfAlbums
    {
        private const int YearDifference = 5;

        internal static void Main()
        {
            var catalogXml = new XmlDocument();
            catalogXml.Load("../../catalog.xml");

            var prices = ExtractAllPricesOfAlbums(catalogXml);
            Console.WriteLine("Extracted price(s): {0}", string.Join(", ", prices));
        }

        private static ICollection<string> ExtractAllPricesOfAlbums(XmlDocument xmlDocument)
        {
            var prices = new List<string>();
            var albumsXml = xmlDocument.SelectNodes("/catalog/albums/album");

            foreach (XmlNode album in albumsXml)
            {
                var albumYear = int.Parse(album.SelectSingleNode("year").InnerText);

                if (DateTime.Now.AddYears(-albumYear).Year <= YearDifference)
                {
                    var price = album.SelectSingleNode("price").InnerText;
                    prices.Add(price);
                }
            }

            return prices;
        }
    }
}