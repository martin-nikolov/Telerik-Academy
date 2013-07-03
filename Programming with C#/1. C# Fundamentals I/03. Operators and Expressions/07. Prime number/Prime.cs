/*
* 7. Write an expression that checks if given positive
* integer number n (n ≤ 100) is prime. E.g. 37 is prime.
*/

using System;
using System.Linq;

class Prime
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number [0, 100]: ");
        int number = int.Parse(Console.ReadLine());

        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine("{0} {1} prime number", number, isPrime ? "IS" : "IS NOT");
    }
}