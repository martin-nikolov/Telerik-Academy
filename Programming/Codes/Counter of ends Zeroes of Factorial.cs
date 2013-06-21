using System;

class ZeroesOfFactorialNumber
{
    static void Main()
    {
        int factorialNumber = 25; // 25! = 15511210043330985984000000 -> 6 zeroes
        int p = 5;
        int zeroCount = 0;

        while (factorialNumber >= p)
        {
            zeroCount += factorialNumber / p;
            p *= 5;
        }

        Console.WriteLine("{0}! ends with {1} zero(s).", factorialNumber, zeroCount);
    }
}