// We are given numbers N and M and the following operations:
// N = N+1, N = N+2, N = N*2
// Write a program that finds the shortest sequence of operations 
// from the list above that starts from N and finishes in M. Hint: use a queue.
// Example: N = 5, M = 16, Sequence: 5 i?  7 i?  8 i?  16

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        int m = 16;
        Console.WriteLine("N= {0}", n);
        Console.WriteLine("M = {0}\n", m);

        Queue<int> queue = new Queue<int>();
        Queue<int> queueForN = new Queue<int>();
        Queue<Queue<int>> queueForAll = new Queue<Queue<int>>();
        queue.Enqueue(n);
        queueForN.Enqueue(n);
        queueForAll.Enqueue(queueForN);
        int digit = 0;
        Console.WriteLine("All ways from {0} to {1}. Operations are (+1), (+2) and (*2). \nFirst is the shortest :\n", n, m);
        while (queueForN.Count <= m - n)
        {
            digit = queue.Dequeue();
            queueForN = queueForAll.Dequeue();

            // Make queue from all digit to that Current digit
            Queue<int> first = new Queue<int>(queueForN);
            first.Enqueue(digit + 1);
            queue.Enqueue(digit + 1);
            queueForAll.Enqueue(first);
            if (digit + 1 == m)
            {
                PrintQueue(digit + 1, first);
            }

            // Make queue from all digit to that Current digit
            Queue<int> second = new Queue<int>(queueForN);
            second.Enqueue(digit + 2);
            queue.Enqueue(digit + 2);
            queueForAll.Enqueue(second);
            if (digit + 2 == m)
            {
                PrintQueue(digit + 2, second);
            }

            // Make queue from all digit to that Current digit
            Queue<int> third = new Queue<int>(queueForN);
            third.Enqueue(digit * 2);
            queue.Enqueue(digit * 2);
            queueForAll.Enqueue(third);
            if (digit * 2 == m)
            {
                PrintQueue(digit * 2, third);
            }
        }
    }

    static void PrintQueue(int digit, Queue<int> queue)
    {
        Console.Write("Digit:{0} - Way to this digit : ", digit);
        foreach (int dig in queue)
        {
            Console.Write("{0} ", dig);
        }
        Console.WriteLine();
    }
}