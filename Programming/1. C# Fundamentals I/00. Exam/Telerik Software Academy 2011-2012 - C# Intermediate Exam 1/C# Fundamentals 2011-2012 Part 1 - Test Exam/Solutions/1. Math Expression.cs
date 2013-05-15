using System;

class MathExpression
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());

        decimal nominator = N * N + 1 / (M * P) + 1337;
        decimal denominator = N - 128.523123123M * P;
        decimal sin = (decimal)Math.Sin((int)M % 180);

        Console.WriteLine("{0:F6}", nominator / denominator + sin);
    }
}