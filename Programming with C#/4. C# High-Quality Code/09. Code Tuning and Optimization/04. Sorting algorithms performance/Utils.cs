namespace Performance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Utils
    {
        private static readonly Random rnd = new Random();

        public static int[] GetArrayWithRandomIntegers(int capacity)
        {
            var randomIntegers = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                randomIntegers[i] = rnd.Next(int.MinValue, int.MaxValue);
            }

            return randomIntegers.ToArray();
        }

        public static double[] GetArrayWithRandomDoubles(int capacity)
        {
            var randomDoubles = new double[capacity];

            for (int i = 0; i < capacity; i++)
            {
                randomDoubles[i] = rnd.NextDouble() * rnd.Next(int.MinValue, int.MaxValue);
            }

            return randomDoubles.ToArray();
        }

        public static string[] GetArrayWithRandomStrings(int capacity)
        {
            var randomStrings = new string[capacity];

            for (int i = 0; i < capacity; i++)
            {
                randomStrings[i] = new string(GetArrayWithRandomChars());
            }

            return randomStrings.ToArray();
        }

        public static bool AreSequencesEqual<T>(IList<T> arr1, IList<T> arr2) where T : IComparable
        {
            for (int i = 0; i < arr1.Count; i++)
            {
                if (arr1[i].CompareTo(arr2[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static char[] GetArrayWithRandomChars()
        {
            var count = rnd.Next(1, 15);
            var chars = new char[count];

            for (int i = 0; i < count; i++)
            {
                chars[i] = (char)('a' + rnd.Next(0, 26));

                if (rnd.Next() % 2 == 0)
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
            }

            return chars.ToArray();
        }
    }
}