using System;
using System.Linq;

class MinDigit
{
    static void Main()
    {
        string number = Console.ReadLine();
        int min = 10;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] - 48 < min && number[i] - 48 != 0)
            {
                min = number[i] - 48;
            }
        }

        Console.WriteLine(min);
    }
}