using System;

class NumberOnPrimeDivisors
{
    static void Main(string[] args)
    {
        int n = 520;
        int how = 0;
        Console.Write("{0} = ", n);

        for (int i = 2; n != 1; i++)
        {
            while (n % i == 0)
            {
                ++how;
                n /= i;
            }

            for (int j = 0; j < how; j++)
                Console.Write(i + " ");

            how = 0;
        }

        Console.WriteLine();
    }
}