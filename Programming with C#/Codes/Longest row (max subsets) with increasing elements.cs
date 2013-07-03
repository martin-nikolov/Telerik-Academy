using System;
 
class MaxIncreasingSequence
{
    static void Main()
    {
        int[] arr = { 9, 6, 2, 7, 4, 7, 5, 6, 7, 8, 4 };
        int[] len = new int[arr.Length];
 
        len[0] = 1;
        int index = 0; // Index of the last element of the longest subsequence
        for (int x = 0; x < arr.Length; x++)
        {
            len[x] = 1;
            for (int i = 0; i < x; i++)
            {
                if (arr[i] < arr[x] && len[i] + 1 > len[x])
                {
                    len[x] = len[i] + 1;
                }
            }
            if (len[x] > len[index])
            {
                index = x;
            }
        }
 
        Console.WriteLine("Longest sequence:");
        
        int prevIndex = index;            // Start from the biggest element
        Console.Write(arr[index] + " ");  // Print the biggest element
 
        // Back iterating and print smaller elements
        for (; index >= 0; index--)
        {
            // Check if there is smaller element from the last 
            // found and if the length of the subsequence matches
            if (arr[index] < arr[prevIndex] && len[prevIndex] == len[index] + 1 )
            {
                Console.Write(arr[index] + " ");
                prevIndex = index;  // Save the index of the new last element
            }
        }    
    }
}