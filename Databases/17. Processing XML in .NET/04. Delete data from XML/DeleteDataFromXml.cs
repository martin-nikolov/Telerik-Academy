/*
 * 4. Using the DOM parser write a program to delete from
 * catalog.xml all albums having price > 20.
 */

namespace ProcessingXml
{
    using System;
    using System.Linq;
    using System.Xml;

    public class DeleteDataFromXml
    {
        internal static void Main()
        {
            var catalogXml = new XmlDocument();
            catalogXml.Load("../../catalog.xml");

            RemoveAllAlbumsWithPriceBiggerThan(catalogXml, 15);

            catalogXml.Save("../../new-catalog.xml");
        }

        private static void RemoveAllAlbumsWithPriceBiggerThan(XmlDocument xmlDocument, double price)
        {
            var albumsParent = xmlDocument.SelectSingleNode("catalog/albums");
            var albumsXml = albumsParent.SelectNodes("album");

            foreach (XmlNode album in albumsXml)
            {
                var priceXml = album.SelectSingleNode("price").InnerText.Replace("$", string.Empty);
                var priceAsDouble = double.Parse(priceXml);

                if (priceAsDouble > price)
                {
                    albumsParent.RemoveChild(album);
                }
            }
        }
    }
}