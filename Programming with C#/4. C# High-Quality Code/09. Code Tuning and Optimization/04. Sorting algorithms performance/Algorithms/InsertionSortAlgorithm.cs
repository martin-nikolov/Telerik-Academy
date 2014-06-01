namespace Performance.Algorithms
{
    using System;
    using System.Collections.Generic;

    public class InsertionSortAlgorithm<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            T x = default(T);
            int i, j;
            int left, right, middle;

            for (i = 1; i < collection.Count; i++)
            {
                x = collection[i];
                left = 0;
                right = i - 1;

                // Binary search
                while (left <= right)
                {
                    middle = (left + right) / 2;

                    if (x.CompareTo(collection[middle]) < 0)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }

                for (j = i - 1; j >= left; j--)
                {
                    collection[j + 1] = collection[j];
                }

                collection[left] = x;
            }
        }
    }
}