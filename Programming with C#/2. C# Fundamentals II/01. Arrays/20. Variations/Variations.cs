/*
* 20. Write a program that reads two numbers N and K and generates
* all the variations of K elements from the set [1..N]. 
* Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
*/

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

        // Initialize the array with ones 'k' times 
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
                else
                {
                    elem[i] = c = 1;
                }
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