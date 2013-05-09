/*
* 10. We are given N and M and the following operations:
* N = N+1
* N = N+2
* N = N*2
* Write a program, which finds the shortest subsequence from the operations, which starts with N and ends with M. Use queue.
* Example: N = 5, M = 16
* Subsequence: 5 -> 7 -> 8 -> 16
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        int m = 16;
        Queue<int> path = new Queue<int>();
        path.Enqueue(m);
        Console.Write("Shortest path between {0} and {1} is: ", n, m);

        while (m / 2 >= n)
        {
            path.Enqueue(m / 2);
            m = m / 2;
        }

        while (m - 2 >= n)
        {
            path.Enqueue(m - 2);
            m = m - 2;
        }

        while (m - 1 >= n)
        {
            path.Enqueue(m - 1);
            m = m - 1;
        }

        for (int i = path.Count - 1; i >= 0; i--)
        {
            if (i > 0)
                Console.Write(path.ElementAt(i) + " -> ");
            else
                Console.Write(path.ElementAt(i) + "\n\n");
        }
    }
}