/*
* 5. Write a program that calculates N!*K! / (K-N)! for given N and K (1 < N < K).
*/

// N = 6;
// K = 10;
// 1.2.3.4.5.6 * 1.2.3.4.5.6.7.8.9.10 => N * K
// (K-N)! => 4! => 1.2.3.4

using System;
using System.Linq;
using System.Numerics;

class FactorialExpression
{
    static void Main()
    {
        Console.WriteLine("You should to enter two numbers (K > N > 1)");

        Console.Write("-> N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("-> K: ");
        int k = int.Parse(Console.ReadLine());

        if (k < n || n < 1 || k < 1)
        {
            Console.WriteLine("\nWrong input! Тhe condition is not satisfied (K > N > 1)...\n");
            return;
        }

        BigInteger factorial = 1;
        for (int i = k - n + 1; i <= k; i++)
        {
            factorial *= i;

            if (i == k)
            {
                i = 2;

                while (i <= n)
                {
                    factorial *= i;
                    i++;
                }

                break;
            }
        }

        Console.WriteLine("\nResult: {0}!*{1}!/({1}-{0})! = {2}\n", n, k, factorial);
    }
}