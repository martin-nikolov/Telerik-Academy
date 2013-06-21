using System;

class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool[] prime = new bool[n + 1];

        // Finding all prime numbers to 'n'
        for (int i = 2; i < prime.Length; i++) // i <= Math.Sqrt(n) or slower -> |i < n| -or- |i < n / 2|
        {
            if (prime[i] == false) // Skip these which is not prime
            {
                Console.Write("{0} ", i); // Printing current prime number

                for (int j = i * i; j < prime.Length; j += i) // j = i + i
                    prime[j] = true;
            }
        }

        Console.WriteLine();
    }
}