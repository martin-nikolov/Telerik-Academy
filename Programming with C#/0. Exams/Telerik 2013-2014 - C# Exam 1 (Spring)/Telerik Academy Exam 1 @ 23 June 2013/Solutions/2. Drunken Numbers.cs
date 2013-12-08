using System;
using System.Linq;

class DrunkenNumbers
{
    static int mitkoBeers = 0;
    static int vladkoBeers = 0;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            CalculateBeersForEach(int.Parse(Console.ReadLine()));

        if (mitkoBeers > vladkoBeers)
        {
            Console.WriteLine("M {0}", mitkoBeers - vladkoBeers);
        }
        else if (vladkoBeers > mitkoBeers)
        {
            Console.WriteLine("V {0}", vladkoBeers - mitkoBeers);
        }
        else
        {
            Console.WriteLine("No {0}", mitkoBeers + vladkoBeers);
        }
    }

    static void CalculateBeersForEach(int number)
    {
        string digits = Math.Abs(number).ToString();

        for (int j = 0; j < digits.Length; j++)
        {
            if (j < digits.Length / 2)
                mitkoBeers += digits[j] - 48;
            else
                vladkoBeers += digits[j] - 48;
        }

        // Special case: number consists of odd number of digits
        // the middle digit is shared between both competitors
        if (digits.Length % 2 != 0)
            mitkoBeers += digits[digits.Length / 2] - 48;
    }
}