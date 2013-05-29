using System;

class SevenlandNumbers
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());

        int digit0 = k % 10;
        int digit1 = k / 10 % 10;
        int digit2 = k / 100 % 10;
        int digit3 = k / 1000 % 10;

        digit0++;

        if (digit0 == 7)
        {
            digit0 = 0;
            digit1++;

            if (digit1 == 7)
            {
                digit1 = 0;
                digit2++;

                if (digit2 == 7)
                {
                    digit2 = 0;
                    digit3++;
                }
            }
        }

        int nextK = digit3 * 1000 + digit2 * 100 + digit1 * 10 + digit0;

        Console.WriteLine(nextK);
    }
}