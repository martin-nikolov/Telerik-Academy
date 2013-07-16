/*
* 15. Write a program that finds all prime numbers in the 
* range [1...10 000 000]. Use the sieve of Eratosthenes algorithm.
*/

using System;
using System.Linq;

class SieveOfEratosthenes
{
    static void Main()
    {
        bool[] primes = new bool[2000]; // new bool[10000000];

        // Find all prime numbers to N
        for (int i = 2; i < Math.Sqrt(primes.Length); i++)
        {
            // Skip these which is not prime
            if (primes[i] == false)
            {
                for (int j = i * i; j < primes.Length; j += i)
                    primes[j] = true;
            }
        }

        // Print all prime numbers to N
        for (int i = 2; i < primes.Length; i++)
            if (!primes[i]) Console.Write(i + " ");
    }
}