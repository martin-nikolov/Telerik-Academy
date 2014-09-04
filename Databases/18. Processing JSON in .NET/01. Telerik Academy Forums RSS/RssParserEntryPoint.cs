/*
 * Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
 * 
 *   1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
 *   2. Download the content of the feed programmatically
 *     * You can use WebClient.DownloadFile()
 *   3. Parse the XML from the feed to JSON
 *   4. Using LINQ-to-JSON select all the question titles and print them to the console
 *   5. Parse the JSON string to POCO
 *   6. Using the parsed objects create a HTML page that lists all questions from the 
 *      RSS their categories and a link to the question's page
 */

namespace ProcessingJson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ProcessingJson.Common;
    using ProcessingJson.Contracts;
    using ProcessingJson.JsonMapping;

    public class RssParserEntryPoint
    {
        private const string RssFeedUrl = @"http://forums.academy.telerik.com/feed/qa.rss";
        private const string RssFeedFilePath = @"../../rss.txt";
        private const string HtmlPagePath = @"../../index.html";

        public static void Main()
        {
            Console.Write("Loading...");

            DownloadContentFromUrl(RssFeedUrl, RssFeedFilePath);

            var fileContent = Utility.GetFileTextContent(RssFeedFilePath);
            var xml = ConvertStringToXml(fileContent);
            var json = ConvertXmlToJson(xml);

            var questionTitles = SelectAllQuestionTitle(json);
            PrintAllQuestionTitles(questionTitles);

            // Deserialize json to POCO objects - type Item
            // Print name and publish date of the items
            // Return deserialized objects casted to type Item
            var pocoObjects = ConvertJsonToPoco(json);

            CreateHtmlPage(pocoObjects);
        }

        private static void DownloadContentFromUrl(string url, string fileName)
        {
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(url, fileName);
            }

            Console.WriteLine("\r-> RSS Feed File was downloaded succesfully...");
        }

        private static XDocument ConvertStringToXml(string text)
        {
            var xml = XDocument.Parse(text);
            return xml;
        }

        private static string ConvertXmlToJson(XDocument xml)
        {
            var xmlToJson = JsonConvert.SerializeXNode(xml);
            return xmlToJson;
        }

        private static IList<IListItem> ConvertJsonToPoco(string json)
        {
            Console.WriteLine("\n------------------- JSON to POCO Objects: -------------------\n");

            var jsonObj = JObject.Parse(json);
            var itemsProjection = jsonObj["rss"]["channel"]["item"];
            var pocoObjects = new List<IListItem>();

            foreach (var item in itemsProjection)
            {
                var deserializedObject = JsonConvert.DeserializeObject<Item>(item.ToString());
                pocoObjects.Add(deserializedObject);
                Console.WriteLine(deserializedObject);
            }

            return pocoObjects;
        }

        private static void CreateHtmlPage(IList<IListItem> pocoObjects)
        {
            var htmlGenerator = new HtmlPageGenerator();
            htmlGenerator.CreateHtmlPage(HtmlPagePath, pocoObjects);

            Console.WriteLine("\n-> Html page was created successfully...\n");
        }

        private static IEnumerable<object> SelectAllQuestionTitle(string json)
        {
            var jsonObj = JObject.Parse(json);
            var questionTitles = jsonObj["rss"]["channel"]["item"].Select(i => i["title"]);
            return questionTitles;
        }

        private static void PrintAllQuestionTitles(IEnumerable<object> questionTitles)
        {
            Console.WriteLine("\n------------------- All question titles: -------------------\n");

            foreach (var title in questionTitles)
            {
                Console.WriteLine("- {0}", title);
            }
        }
    }
}