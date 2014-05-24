namespace Algorithms
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class SearchingAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            // Public method -> exceptions
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(value != null, "Searching value is null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Invalid startIndex value.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "Invalid endIndex value.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}