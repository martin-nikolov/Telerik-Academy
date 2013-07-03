using System;

class MersennePrimeNumbers
{
    static void Main()
    {
        bool[] prime = new bool[550000];

        // Finding all prime numbers to N
        // Sieve of Eratosthenes
        for (int i = 2; i <= Math.Sqrt(prime.Length); i++)
        {
            if (prime[i] == false)
            {
                for (int j = i * i; j < prime.Length; j += i)
                    prime[j] = true;
            }
        }

        Console.WriteLine("Some of Mersenne prime numbers (2^p - 1, where 'p' is prime ): ");
        for (long i = 2; i < prime.Length; i++)
        {
            if (prime[i] == false)
            {
                long index = (int)(Math.Pow(2, i) - 1);

                if (index >= prime.Length) return;
                else if (prime[index] == false) Console.WriteLine(i + " -> " + index);
            }
        }
    }
}