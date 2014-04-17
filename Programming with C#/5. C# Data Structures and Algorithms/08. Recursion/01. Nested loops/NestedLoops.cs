/*
 * 1. Write a recursive program that simulates the 
 * execution of n nested loops from 1 to n. 
 * 
 * Examples:
 *                            1 1 1
 *                            1 1 2
 *                            1 1 3
 *          1 1               1 2 1
 * n=2  ->  1 2      n=3  ->  ...
 *          2 1               3 2 3
 *          2 2               3 3 1
 *                            3 3 2
 *                            3 3 3 
 */

using System;
using System.Linq;

class NestedLoops
{
    static readonly int[] result = new int[N];

    const int N = 2;

    static void Main()
    {
        IterateNestedLoops(0, N);
    }

    static void IterateNestedLoops(int beginning, int last, int level = 0)
    {
        if (level == N)
        {
            Console.WriteLine(string.Join(" ", result));
            return;
        }

        for (int i = beginning; i < last; i++)
        {
            result[level] = i + 1;
            
            IterateNestedLoops(0, last, level + 1);
        }
    }
}