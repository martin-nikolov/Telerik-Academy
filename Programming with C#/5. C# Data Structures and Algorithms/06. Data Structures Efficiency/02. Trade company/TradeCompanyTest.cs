/*
 * 2. A large trade company has millions of products, each described by barcode,
 * vendor, title and price. Implement a data structure to store them that allows
 * fast retrieval of all products in given price range [x…y]. 
 * Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 
 */

using System;
using System.Diagnostics;
using System.Linq;

class TradeCompanyTest
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
            string title = rnd.Next(int.MaxValue).ToString();
            decimal price = rnd.Next(20000) / 100;

            store.AddProduct(new Product(title, price));
        }

        sw.Stop();

        Console.WriteLine("\rAdding products -> Elapsed time: {0}", sw.Elapsed);

        sw.Restart();

        // 5 000 000 price searches
        for (int i = 0; i < 5000000; i++)
        {
            int min = rnd.Next(200), max = rnd.Next(250, 2000);

            store.SearchInPriceRange(min, max);
        }

        sw.Stop();

        Console.WriteLine("\nSearching products -> Elapsed time: {0}\n", sw.Elapsed);
    }
}