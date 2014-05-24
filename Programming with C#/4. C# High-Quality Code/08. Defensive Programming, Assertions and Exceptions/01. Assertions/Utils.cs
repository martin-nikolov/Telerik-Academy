namespace Algorithms
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class Utils
    { 
        internal static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(arr.Length > 0, "Array is empty.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Invalid startIndex value.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "Invalid endIndex value.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        internal static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "x swapping value is null.");
            Debug.Assert(y != null, "y swapping value is null.");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}