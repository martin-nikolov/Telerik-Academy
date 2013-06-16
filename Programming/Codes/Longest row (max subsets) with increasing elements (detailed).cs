using System;

public static class MaxIncreasingSequence
{
    /// <summary>
    /// This function printing subsequances of smaller elements before this of the pointed index
    /// </summary>
    /// <param name="arr">The array in which we search</param>
    /// <param name="index">Index of element before which to search</param>
    public static void PrintSequenceAtIndex(this int[] arr, int index)
    {
        int prevIndex = index;
        Console.Write(arr[index] + " ");

        // Back iterating to the elements
        for (; index >= 0; index--)
        {
            // Check if there is smaller element from the last found
            if (arr[index] < arr[prevIndex]) 
            {
                Console.Write(arr[index] + " ");
                prevIndex = index;  // Save the index of the new last element
            }
        }
    }

    static void Main()
    {
        int[] arr = { 9, 6, 2, 7, 4, 7, 5, 6, 7, 8, 4 };
        int[] len = new int[arr.Length];

        Console.WriteLine("Array: {0}", string.Join(", ", arr));
        Console.WriteLine();

        len[0] = 1;
        int indexOfBiggestSubset = 0;

        for (int x = 0; x < arr.Length; x++)
        {
            Console.WriteLine("{0}: At element {1}", x, arr[x]);
            // At first the max length is 1
            len[x] = 1;

            // Search in previous elements for smaller value
            for (int i = 0; i < x; i++)
            {
                // The first check finds smaller element and second - check if can be 
                // formed with this element bigger subsequence from the existed
                if (arr[i] < arr[x])
                {
                    if (len[i] + 1 > len[x])
                    {
                        // Save the length of found subsequence of x with element 'i'
                        len[x] = len[i] + 1;
                    }

                    // How works the code:
                    Console.WriteLine("Found smaller element:  {0} -> {1}", arr[x], arr[i]);
                    Console.WriteLine("The new sequence is {0} with the sequence at {1}", arr[x], arr[i]);
                    Console.Write("Sequence: {0} ", arr[x]);
                    arr.PrintSequenceAtIndex(i);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            // Check if this is the biggest subsequence until now
            if (len[x] > len[indexOfBiggestSubset])
            {
                indexOfBiggestSubset = x;
            }
            Console.WriteLine();
        }

        Console.WriteLine("All sequences found:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("{0}: number: {1} - lenght: {2}  sequence: ", i, arr[i], len[i]);
            arr.PrintSequenceAtIndex(i);
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Longest sequence: ");
        arr.PrintSequenceAtIndex(indexOfBiggestSubset);
        Console.ReadKey();
    }
}