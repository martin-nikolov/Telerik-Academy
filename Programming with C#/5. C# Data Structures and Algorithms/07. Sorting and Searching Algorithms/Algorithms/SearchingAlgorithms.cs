namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public static class SearchingAlgorithms
    {
        public static int LinearSearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            for (int index = 0; index < collection.Count; index++)
            {
                if (collection[index].CompareTo(item) == 0)
                {
                    return index;
                }
            }

            return -1;
        }

        public static int BinarySearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            int left = 0, right = collection.Count - 1, middle = 0;

            while (left <= right)
            {
                middle = GetMedian(left, right);

                if (collection[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (collection[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        private static int GetMedian(int left, int right)
        {
            return left + ((right - left) >> 1);
        }
    }
}