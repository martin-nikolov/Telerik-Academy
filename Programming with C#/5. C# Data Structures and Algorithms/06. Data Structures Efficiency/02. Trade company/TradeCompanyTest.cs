/*
 * 2. A large trade company has millions of products, each described by barcode,
 * vendor, title and price. Implement a data structure to store them that allows
 * fast retrieval of all products in given price range [x…y]. 
 * Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 
 */

namespace DataStructuresEfficiency
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class TradeCompanyTest
    {
        private static readonly Random rnd = new Random();
        private static readonly Stopwatch sw = new Stopwatch();

        public static void Main()
        {
            var store = new Store();

            Console.Write("Please wait... ");

            sw.Start();
            AddProducts(store); // 500 000 products
            sw.Stop();

            Console.WriteLine("\rAdding products -> Elapsed time: {0}", sw.Elapsed);

            sw.Restart();
            SearchProductsInPriceRange(store); // 5 000 000 price searches
            sw.Stop();

            Console.WriteLine("\nSearching products -> Elapsed time: {0}\n", sw.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = 500000)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string title = rnd.Next(int.MaxValue).ToString();
                decimal price = rnd.Next(20000) / 100;
                store.AddProduct(new Product(title, price));
            }
        }

        private static void SearchProductsInPriceRange(Store store, int numOfProductsToSearch = 5000000)
        {
            for (int i = 0; i < numOfProductsToSearch; i++)
            {
                int min = rnd.Next(200), max = rnd.Next(250, 2000);
                store.SearchInPriceRange(min, max);
            }
        }
    }
}