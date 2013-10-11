using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ExtensionSet
    {
        public static dynamic Sum<T>(this IEnumerable<T> elements)
        {
            dynamic sum = default(T);

            foreach (T item in elements)
                sum += item;

            return sum;
        }

        public static dynamic Product<T>(this IEnumerable<T> elements)
        {
            dynamic sum = 1;

            foreach (T item in elements)
                sum *= item;

            return sum;
        }

        public static dynamic Average<T>(this IEnumerable<T> elements)
        {
            return elements.Sum() / elements.Count();
        }

        public static T Min<T>(this IEnumerable<T> elements)
        {
            dynamic min = long.MaxValue;

            foreach (T item in elements)
                if (item < min)
                    min = item;

            return min;
        }

        public static T Max<T>(this IEnumerable<T> elements)
        {
            dynamic max = long.MinValue;

            foreach (T item in elements)
                if (item > max)
                    max = item;

            return max;
        }

        public static int Count<T>(this IEnumerable<T> elements)
        {
            int count = 0;

            foreach (T item in elements)
                count++;

            return count;
        }
    }
}