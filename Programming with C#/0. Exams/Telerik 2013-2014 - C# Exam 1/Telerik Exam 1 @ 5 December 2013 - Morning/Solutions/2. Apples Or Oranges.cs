using System;
using System.Linq;

class ApplesOrOranges
{
    static void Main()
    {
        var digits = Console.ReadLine().Where(ch => ch != '-').Select(ch => ch - '0');

        int sumOfOddNumbers = digits.Where(ch => (ch & 1) != 0).Sum();
        int sumOfEvenNumbers = digits.Where(ch => (ch & 1) == 0).Sum();

        Console.WriteLine(sumOfOddNumbers > sumOfEvenNumbers ? "oranges " + sumOfOddNumbers
                          : sumOfOddNumbers == sumOfEvenNumbers ? "both " + sumOfOddNumbers
                          : "apples " + sumOfEvenNumbers);
    }
}