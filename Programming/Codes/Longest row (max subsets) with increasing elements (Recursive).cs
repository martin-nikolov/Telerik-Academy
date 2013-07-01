using System;

class Program
{
    static void Check(int[] arr, int[] indices, int k)
    {
        // Reversed because of recursion
        for (int i = 0; i < k; i++) if (arr[indices[i]] > arr[indices[i + 1]]) return; 
        
        for (int i = 0; i <= k; i++) Console.Write(arr[indices[i]] + (i == k ? "\n" : " "));

        Environment.Exit(0);
    }

    static void Combination(int[] arr, int[] indices, int k, int i, int next)
    {
        if (i > k) return;

        for (int j = next; j < arr.Length; j++)
        {
            indices[i] = j;

            if (i == k) Check(arr, indices, k);

            Combination(arr, indices, k, i + 1, j + 1);
        }
    }

    static void Main()
    {
        int[] arr = { 6, 6, 5, 4, 3, 2, 1, 3, 1, 2, 3, 4, 5, 6, 3, 2, 1, 2, 1, 2, 3 };

        int[] indices = new int[arr.Length];
        for (int i = arr.Length - 1; i >= 0; i--) Combination(arr, indices, i, 0, 0);
    }
}