namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    public static class ArrayExtensions
    {
        /// <summary>
        /// Gets the minimal number of this collecion
        /// </summary>
        /// <typeparam name="T">The number type</typeparam>
        /// <param name="collection">The collection contains the numbers</param>
        /// <returns>The minimal number of this collecion</returns>
        public static T Min<T>(this IEnumerable<T> collection)
        {
            dynamic min = double.MaxValue;

            foreach (T element in collection)
            {
                if (element < min)
                {
                    min = element;
                }
            }

            return min;
        }

        /// <summary>
        /// Gets the maximal number of this collecion
        /// </summary>
        /// <typeparam name="T">The number type</typeparam>
        /// <param name="collection">The collection contains the numbers</param>
        /// <returns>The maximal number of this collecion</returns>
        public static T Max<T>(this IEnumerable<T> collection)
        {
            dynamic max = double.MinValue;

            foreach (T element in collection)
            {
                if (element > max)
                {
                    max = element;
                }
            }

            return max;
        }

        /// <summary>
        /// Gets the sum of the numbers of this collecion
        /// </summary>
        /// <typeparam name="T">The number type</typeparam>
        /// <param name="collection">The collection contains the numbers</param>
        /// <returns>The sum of the numbers in this collecion</returns>
        public static double Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;

            foreach (T item in collection)
                sum += item;

            return sum;
        }

        /// <summary>
        /// Gets the average sum of the numbers of this collecion
        /// </summary>
        /// <typeparam name="T">The number type</typeparam>
        /// <param name="collection">The collection contains the numbers</param>
        /// <returns>The average sum of the numbers in this collecion</returns>
        public static double Average<T>(this IEnumerable<T> collection)
        {
            return collection.Sum() / collection.Count();
        }

        /// <summary>
        /// Gets the number of elements that are contained in a collecion.
        /// </summary>
        /// <typeparam name="T">The number type</typeparam>
        /// <param name="collection">The collection contains the numbers</param>
        /// <returns>The number of elements in a sequence</returns>
        public static int Count<T>(this IEnumerable<T> collection)
        {
            int count = 0;

            foreach (T element in collection)
                count++;

            return count;
        }
    }
}