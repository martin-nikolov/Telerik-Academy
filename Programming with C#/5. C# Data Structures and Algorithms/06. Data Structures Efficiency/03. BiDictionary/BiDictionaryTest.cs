namespace DataStructures
{
    using System;

    public class BiDictionaryTest
    {
        public static void Main()
        {
            var biDictionary = new BiDictionary<int, string, string>(true);

            // Test Add method
            biDictionary.Add(1, "One", "Duplicate");
            biDictionary.Add(1, "One", "Duplicate");
            biDictionary.Add(1, "Two", "From One");

            biDictionary.Add(2, "Two", "C#");
            biDictionary.Add(2, "Two-2", "Coffee");

            biDictionary.Add(3, "Three", "C#");
            biDictionary.Add(3, "Three-2", "Python");

            biDictionary.Add(4, "Four", "1");
            biDictionary.Add(4, "Four", "2");

            /* ---------------------------------------------- */

            // Test Get methods
            Console.WriteLine(string.Join(", ", biDictionary.GetByFirstKey(1)));
            Console.WriteLine(string.Join(", ", biDictionary.GetBySecondKey("Two")));
            Console.WriteLine(string.Join(", ", biDictionary.GetByTwoKeys(1, "One")));

            /* ---------------------------------------------- */

            // Test Value property
            PrintAllValues(biDictionary);

            /* ---------------------------------------------- */

            // Test - Remove by first key method
            biDictionary.RemoveByFirstKey(4);

            PrintAllValues(biDictionary);

            /* ---------------------------------------------- */

            // Test - Remove by second key method
            biDictionary.RemoveBySecondKey("Two");

            PrintAllValues(biDictionary);

            /* ---------------------------------------------- */

            // Test - Remove by two keys method
            biDictionary.RemoveByTwoKeys(1, "One");

            PrintAllValues(biDictionary);

            /* ---------------------------------------------- */

            // Test - Clear method
            biDictionary.Clear();

            PrintAllValues(biDictionary);
        }
  
        public static void PrintAllValues<K1, K2, V>(IBiDictionary<K1, K2, V> biDictionary)
        {
            Console.WriteLine("\nCount: " + biDictionary.Count);

            foreach (var value in biDictionary.Values)
                Console.WriteLine(value);
        }
    }
}