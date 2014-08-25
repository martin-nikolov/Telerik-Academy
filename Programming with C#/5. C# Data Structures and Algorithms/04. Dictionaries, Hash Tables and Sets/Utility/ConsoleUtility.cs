namespace Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ConsoleUtility
    {
        /// <summary>
        /// Works for sbyte, byte, int, uint, long, ulong, double, decimal, string, char, etc.
        /// </summary>
        public static IEnumerable<T> ReadSequenceOfElements<T>() where T : IComparable
        {
            var numbers = new List<T>();
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                T number = (T)Convert.ChangeType(input, typeof(T));
                numbers.Add(number);

                input = Console.ReadLine();
            }

            return numbers;
        }

        public static string GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File does not exist. File name: " + fullPath);
            }

            string textContent = string.Empty;

            using (var reader = new StreamReader(fullPath))
            {
                textContent = reader.ReadToEnd();
            }

            return textContent;
        }

        public static void PrintDictionaryElements<T>(IDictionary<T, int> dict)
        {
            foreach (var element in dict)
            {
                Console.WriteLine("{0} -> {1} time(s).", element.Key, element.Value);
            }
        }
    }
}