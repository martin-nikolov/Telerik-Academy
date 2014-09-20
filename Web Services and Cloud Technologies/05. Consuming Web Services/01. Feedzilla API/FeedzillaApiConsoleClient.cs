/*
 * 1. Write a console application, which searches for news articles by given 
 * a query string and a count of articles to retrieve. The application should
 * ask the user for input and print the Titles and URLs of the articles.
 * For news articles search use the Feedzilla API and use one of WebClient,
 * HttpWebRequest or HttpClient.
 */

namespace FeedZillaApi
{
    using System;
    using System.Linq;
    using FeedZillaApi.Models;

    public class FeedzillaApiConsoleClient
    {
        private static readonly FeedzillaConsumer feedZillaConsumer = new FeedzillaConsumer();
        private static readonly Action<Article> articleAction = (a) => Console.WriteLine("Title: {0}\nUrl: {1}\n", a.Title, a.Url);

        internal static void Main()
        {
            Console.Write("Enter a search pattern (for example: 'bulgaria'): ");
            string searchPattern = Console.ReadLine();

            Console.Write("Number of articles to take: ");
            int articlesCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nArticles:");
            feedZillaConsumer.GetArticles(searchPattern, articlesCount, articleAction);
        }
    }
}