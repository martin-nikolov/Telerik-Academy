using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
 
class Tribonacci
{
    static void Main()
    {
        List<BigInteger> Trib = new List<BigInteger>();
        for (int i = 0; i < 3; i++)
        {
            Trib.Add(long.Parse(Console.ReadLine()));
        }
 
        int n = int.Parse(Console.ReadLine());
 
        for (int i = 3; i < n; i++)
        {
            Trib.Add(Trib[Trib.Count - 3] + Trib[Trib.Count - 2] + Trib[Trib.Count - 1]);
        }
 
        Console.WriteLine(Trib[n - 1]);
    }
}