using System;
using System.Linq;
using System.Numerics;

class AstrologicalDigits
{
    static void Main()
    {
        string n = Console.ReadLine();

        if (n.Contains('.')) n = n.Remove(n.IndexOf('.'), 1);
        if (n.Contains('-')) n = n.Remove(0, 1);

        BigInteger sum = BigInteger.Parse(n);

        while (sum > 9)
        {
            sum = 0;

            for (int i = 0; i < n.Length; i++)
                sum += n[i] - 48;

            n = sum.ToString();
        }

        Console.WriteLine(sum);

    }
}