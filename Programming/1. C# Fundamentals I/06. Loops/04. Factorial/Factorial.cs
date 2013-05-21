/*
* 4. Write a program that calculates N!/K! for given N and K (1 < K < N).
*/

using System;
using System.Linq;
using System.Numerics;

class Factorial
{
    static void Main()
    {
        Console.WriteLine("You should to enter two numbers (N > K > 1)");

        Console.Write("-> K: ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("-> N: ");
        int n = int.Parse(Console.ReadLine());

        if (n < k || n < 1 || k < 1)
        {
            Console.WriteLine("\nWrong input! Тhe condition is not satisfied (N > K > 1)...\n");
            return;
        }

        BigInteger factorial = 1;
        for (int i = k + 1; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("\nResult: {0}!/{1}! = {2}\n", k, n, factorial);
    }
}