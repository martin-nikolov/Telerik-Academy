using System;

class Program
{
    static void rec(int[] arr, int index, int N, int num)
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
            for (int i = num; i < N + 1; i++)
            {
                arr[index] = i;
                num++;
                rec(arr, index + 1, N, num);
            }
        }
    }

    static void Main(string[] args)
    {
        int N = 5;
        int K = 2;
        int[] myArr = new int[K];

        rec(myArr, 0, N, 1);
    }
}