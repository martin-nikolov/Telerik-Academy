using System;
using System.Linq;

class TripleRotationOfDigits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < 3 && k > 9; i++)
        {
            int remainder = k % 10;
            k = k / 10;

            if (remainder != 0)
            {
                k = (int)(k + remainder * Math.Pow(10, k.ToString().Length));
            }
        }

        Console.WriteLine(k);
    }
}