/*
 * 2. Write a program to read a large collection of products (name + price)
 * and efficiently find the first 20 products in the price range [a…b]. 
 * Test for 500 000 products and 10 000 price searches.
 * Hint: you may use OrderedBag<T> and sub-ranges.
 */

namespace AdvancedDataStructures
{
    using System;
    using System.Diagnostics;

    public class FindProductInRangeTest
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

            Console.WriteLine("\rCount: {0} | Elapsed time: {1}", store.Products.Count, sw.Elapsed);

            sw.Restart();
            SearchInPriceRange(store); // 10 000 price searches
            sw.Stop();

            Console.WriteLine("\nElapsed time: {0}\n", sw.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = 500000)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string name = rnd.Next(int.MaxValue).ToString();
                decimal price = rnd.Next(20000) / 100;
                store.AddProduct(new Product(name, price));
            }
        }

        private static void SearchInPriceRange(Store store, int numOfSearches = 10000)
        {
            for (int i = 0; i < numOfSearches; i++)
            {
                int min = rnd.Next(200), max = rnd.Next(400, 1000);

                store.SearchInPriceRange(min, max);
            }
        }
    }
}