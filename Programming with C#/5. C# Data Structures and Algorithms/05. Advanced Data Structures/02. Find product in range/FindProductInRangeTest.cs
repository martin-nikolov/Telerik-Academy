/*
 * 2. Write a program to read a large collection of products (name + price)
 * and efficiently find the first 20 products in the price range [a…b]. 
 * Test for 500 000 products and 10 000 price searches.
 * Hint: you may use OrderedBag<T> and sub-ranges.
 */

using System;
using System.Diagnostics;

class FindProductInRangeTest
{
    static readonly Random rnd = new Random();
    static readonly Stopwatch sw = new Stopwatch();

    static void Main()
    {
        Store store = new Store();

        Console.Write("Please wait... ");

        sw.Start();

        // 500 000 products
        for (int i = 0; i < 500000; i++)
        {
            string name = rnd.Next(int.MaxValue).ToString();
            decimal price = rnd.Next(20000) / 100;
            
            store.AddProduct(new Product(name, price));
        }

        sw.Stop();

        Console.WriteLine("\rCount: {0} | Elapsed time: {1}", store.Products.Count, sw.Elapsed);

        sw.Restart();

        // 10 000 price searches
        for (int i = 0; i < 10000; i++)
        {
            int min = rnd.Next(200), max = rnd.Next(400, 1000);

            store.SearchInPriceRange(min, max);
        }

        sw.Stop();

        Console.WriteLine("\nElapsed time: {0}\n", sw.Elapsed);
    }
}