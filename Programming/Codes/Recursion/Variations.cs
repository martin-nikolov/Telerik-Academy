using System;

class Program
{
    static void rec(int[] arr, int index, int N)
    {
        if (arr.Length == index)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = 1; i < N + 1; i++)
            {
                arr[index] = i;
                rec(arr, index + 1, N);
            }
        }
    }

    static void Main(string[] args)
    {
        int N = 3; // frontier
        int K = 2; // index
        int[] myArr = new int[K];

        rec(myArr, 0, N);
    }
}