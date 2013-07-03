using System;
using System.Linq;

class Variations
{
    static void Main()
    {
        Console.Write("Enter a number N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a number K: ");
        int k = int.Parse(Console.ReadLine());

        int[] elem = Enumerable.Repeat(1, k).ToArray();

        int c;

        do
        {
            c = 1;
            PrintElements(elem);

            for (int i = 0; i < k; i++)
            {
                elem[i] += c;

                if (elem[i] <= n)
                {
                    c = 0; break;   
                }

                elem[i] = 1; c = 1;
            }
        }
        while (c != 1);
    }
    
    static void PrintElements(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}