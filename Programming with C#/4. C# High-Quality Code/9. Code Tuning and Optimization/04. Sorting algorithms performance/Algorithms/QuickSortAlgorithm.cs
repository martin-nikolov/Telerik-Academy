namespace Performance.Algorithms
{
    using System;
    using System.Collections.Generic;

    public class QuickSortAlgorithm<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            this.QuickSort(collection);
        }

        private void QuickSort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int leftPointer = leftIndex, rightPointer = rightIndex;
            T frontier = collection[(leftIndex + rightIndex) / 2];

            while (leftPointer <= rightPointer)
            {
                while (collection[leftPointer].CompareTo(frontier) < 0)
                {
                    leftPointer++;
                }

                while (collection[rightPointer].CompareTo(frontier) > 0)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    T swap = collection[leftPointer];
                    collection[leftPointer] = collection[rightPointer];
                    collection[rightPointer] = swap;

                    leftPointer++;
                    rightPointer--;
                }
            }

            if (leftPointer < rightIndex)
            {
                this.QuickSort(collection, leftPointer, rightIndex);
            }

            if (leftIndex < rightPointer)
            {
                this.QuickSort(collection, leftIndex, rightPointer);
            }
        }
    }
}