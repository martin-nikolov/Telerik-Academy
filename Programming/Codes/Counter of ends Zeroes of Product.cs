using System;

class ZeroesOfProduct
{
    static void Main()
    {
        int[] numbers = { 25, 4, 20, 11, 13, 15 };
        long product = 1;

        int secondsCount = 0;
        int fifthCount = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int n = numbers[i];
            product *= n;

            while (n % 2 == 0)
            {
                ++secondsCount;
                n /= 2;
            }

            while (n % 5 == 0)
            {
                ++fifthCount;
                n /= 5;
            }
        }

        Console.WriteLine("{0} ends with {1} zero(s).", product, Math.Min(secondsCount, fifthCount));
    }
}