/*
* 9. In the combinatorial mathematics, the Catalan numbers are 
* calculated by the following formula:
* C(n) = (2*n)!/(n+1)!*n!, for n >= 0
*/

// ЗА ПРОВЕРЯВАЩИЯ: 9-та и 10-та задача са всъщност една задача, допусната е грешка в 
// презентацията.

using System;
using System.Linq;
using System.Numerics;

class CatalanFormula
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        uint n = uint.Parse(Console.ReadLine());

        Console.WriteLine("\nC({0}) = {1}\n", n, Fact(2 * n) / (Fact(n + 1) * Fact(n)));
    }

    // Calculate factorial
    static BigInteger Fact(uint n)
    {
        if (n < 1) return 1;

        return n * Fact(n - 1);
    }
}