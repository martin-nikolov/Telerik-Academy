using System;
using System.Linq;

class BinaryPasswords
{
    static void Main()
    {
        var input = Console.ReadLine();
        var pow = input.Where(a => a == '*').Count();

        long baseN = 2, result = 1;

        for (int i = 0; i < pow; i++)
            result *= baseN;

        Console.WriteLine(result);
    }
}