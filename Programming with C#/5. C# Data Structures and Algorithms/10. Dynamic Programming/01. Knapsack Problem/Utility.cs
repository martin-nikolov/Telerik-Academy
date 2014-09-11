namespace DynamicProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Utility
    {
        /// <summary>
        /// Parse input using Regular Expressions - Regex.Matches() method
        /// </summary>
        public static void ParseInput(out Product[] products, out int maximalWeight)
        {
            maximalWeight = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            products = new Product[N];

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                var productName = Regex.Matches(line, @"(\w+).-")
                                       .Cast<Match>()
                                       .First()
                                       .Groups[1].Value;

                var productCharacteristics = Regex.Matches(line, @"(\w+=)+(\d+)")
                                                  .Cast<Match>()
                                                  .Select(a => int.Parse(a.Groups[2].Value))
                                                  .ToArray();

                products[i] = new Product(productName, productCharacteristics[0], productCharacteristics[1]);
            }
        }

        public static void PrintAllProducts(Product[] products)
        {
            Console.WriteLine("------- All products: -------");

            foreach (var product in products)
            {
                Console.WriteLine("- {0}", product);
            }

            Console.WriteLine("-----------------------------\n");
        }

        public static void PrintOptimalSolutions(ICollection<Product>[] solutions)
        {
            Console.WriteLine("Optimal solution(s): ");

            if (solutions.First().Count() == 0)
            {
                Console.WriteLine("- No solution!\n");
                return;
            }

            foreach (var solution in solutions)
            {
                Console.WriteLine("- {0} -> Total Weight: {1} | Total Cost: {2}",
                    string.Join(" | ", solution.Select(p => p.Name)),
                    solution.Sum(p => p.Weight),
                    solution.Sum(p => p.Cost));
            }

            Console.WriteLine();
        }
    }
}