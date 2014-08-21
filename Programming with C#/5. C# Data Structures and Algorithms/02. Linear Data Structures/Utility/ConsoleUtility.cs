namespace Utility
{
    using System;
    using System.Collections.Generic;
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
    }
}