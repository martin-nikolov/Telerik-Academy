using System;
using System.Linq;

class AngryFemaleGPS
{
    static void Main()
    {
        var digits = Console.ReadLine().Where(ch => ch != '-').Select(ch => ch - '0');

        int sumOfOddNumbers = digits.Where(ch => (ch & 1) != 0).Sum();
        int sumOfEvenNumbers = digits.Where(ch => (ch & 1) == 0).Sum();

        Console.WriteLine(sumOfOddNumbers > sumOfEvenNumbers ? "left " + sumOfOddNumbers
                          : sumOfOddNumbers == sumOfEvenNumbers ? "straight " + sumOfOddNumbers
                          : "right " + sumOfEvenNumbers);
    }
}