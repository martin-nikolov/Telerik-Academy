using System;
using System.Linq;

class PeaceOfCake
{
    static void Main()
    {
        long A = int.Parse(Console.ReadLine());
        long B = int.Parse(Console.ReadLine());
        long C = int.Parse(Console.ReadLine());
        long D = int.Parse(Console.ReadLine());

        long nominator = A * D + C * B;
        long denominator = B * D;

        decimal result = (decimal)nominator / denominator;

        Console.WriteLine(result.ToString(result < 1 ? "F22" : Math.Floor(result).ToString()));
        Console.WriteLine("{0}/{1}", nominator, denominator);
    }
}