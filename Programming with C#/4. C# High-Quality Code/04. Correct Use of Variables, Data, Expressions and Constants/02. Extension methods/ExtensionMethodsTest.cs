namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    internal class ExtensionMethodsTest
    {
        static void Main()
        {
            var collection = new List<double> { 1.1, -1.1, 2.2, -2.2, 3.3, -3.3, 4.4, -4.4, 5.5 };
            //var collection = new int[] { 1, -1, 2, -2, 3, -3, 4, -4, 5 };

            Console.WriteLine("Count: {0}\n", collection.Count());

            Console.WriteLine("Min: {0}", collection.Min());
            Console.WriteLine("Max: {0}\n", collection.Max());

            Console.WriteLine("Sum: {0}", collection.Sum());
            Console.WriteLine("Average: {0}\n", collection.Average());
        }
    }
}