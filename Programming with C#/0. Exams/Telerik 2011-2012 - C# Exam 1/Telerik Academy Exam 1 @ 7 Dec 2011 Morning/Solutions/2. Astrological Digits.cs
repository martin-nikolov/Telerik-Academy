using System;
using System.Linq;
using System.Numerics;

class AstrologicalDigits
{
    public static void Main()
    {
        string n = Console.ReadLine();

        if (n.Contains('.')) // can be modified for ','
            n = n.Remove(n.IndexOf('.'), 1);
        if (n.Contains('-'))
            n = n.Remove(0, 1);

        BigInteger m = BigInteger.Parse(n);

        while (m > 9)
        {
            BigInteger sum = 0;
            
            while (m != 0)
            {
                sum += m % 10;
                m = m / 10;
            }

            m = sum;
        }

        Console.WriteLine(m);
    }
}