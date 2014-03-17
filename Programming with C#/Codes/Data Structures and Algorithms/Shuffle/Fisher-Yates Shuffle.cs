namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public static class ShuffleAlgorithms
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Shuffle the collection using Fisher-Yates Shuffle Algorithm with time complexity O(n).
        /// </summary>
        /// <typeparam name="T">Collection element type.</typeparam>
        /// <param name="collection">Collection to shuffle.</param>
        public static void Shuffle<T>(this IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            for (int i = collection.Count; i > 1; i--)
            {
                int j = rnd.Next(i); 

                Swap<T>(collection, j, i);
            }
        }
  
        private static void Swap<T>(IList<T> collection, int j, int i)
        {
            T tmp = collection[j];
            collection[j] = collection[i - 1];
            collection[i - 1] = tmp;
        }
    }
}