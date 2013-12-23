using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class TribonacciTriangle
{
    static void Main(string[] args)
    {
        List<BigInteger> trib = new List<BigInteger>();

        for (int i = 0; i < 3; i++)
        {
            BigInteger num = BigInteger.Parse(Console.ReadLine());
            trib.Add(num);
        }
        int length = int.Parse(Console.ReadLine());

        Console.WriteLine(trib[0]);
        Console.WriteLine(trib[1] + " " + trib[2]);

        for (int i = 3, index = 3; i <= length; i++)
        {
            for (int j = 0; j < i; j++, index++)
            {
                trib.Add(trib[index - 1] + trib[index - 2] + trib[index - 3]);
                Console.Write(trib[trib.Count - 1] + " ");
            }

            Console.WriteLine();
        }
    }
}