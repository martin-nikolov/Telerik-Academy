using System;

class Program
{
    static void Check(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + 1 + (i == arr.Length - 1 ? "\n" : " "));
    }

    static void Permutation(int[] arr, bool[] used, int i)
    {
        if (i == arr.Length)
        {
            Check(arr);
            return;
        }

        for (int j = 0; j < arr.Length; j++)
        {
            if (used[j]) continue;

            arr[i] = j;

            used[j] = true;
            Permutation(arr, used, i + 1);
            used[j] = false;
        }
    }

    static void Main()
    {
        int[] arr = new int[int.Parse(Console.ReadLine())];

        bool[] used = new bool[arr.Length];
        Permutation(arr, used, 0);
    }
}