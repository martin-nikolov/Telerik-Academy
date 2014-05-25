namespace Performance.Algorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSortAlgorithm<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            int swapIndex = 0;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[swapIndex].CompareTo(collection[j]) > 0)
                    {
                        swapIndex = j;
                    }
                }

                this.Swap(collection, i, swapIndex);
            }
        }
  
        private void Swap(IList<T> collection, int i, int swapIndex)
        {
            T swap = collection[i];
            collection[i] = collection[swapIndex];
            collection[swapIndex] = swap;
        }
    }
}