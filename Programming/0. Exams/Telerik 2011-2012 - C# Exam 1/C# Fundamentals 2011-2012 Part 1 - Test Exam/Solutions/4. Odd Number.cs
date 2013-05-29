using System;

class OddNumber
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long oddNumber = 0;

        for (int i = 0; i < n; i++)
        {
            long number = long.Parse(Console.ReadLine());

            oddNumber = oddNumber ^ number;
        }

        Console.WriteLine(oddNumber);
    }
}