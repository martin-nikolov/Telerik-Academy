/*
* 11. * Write a program that converts a number in the range [0...999]
* to a text corresponding to its English pronunciation. 
* 
* Examples:
* 0 -> "Zero"
* 273 -> "Two hundred seventy three"
* 400 -> "Four hundred"
* 501 -> "Five hundred AND one"
* 711 -> "Seven hundred AND eleven"
*/

using System;
using System.Linq;

class NumberName
{
    static readonly string[] Units = 
    { "", "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
    static readonly string[] Decimals = 
    { "", "TEN", "ELEVEN", "TWELVE", "THIRDTEEN", "FOURTHEN", "FIFTHEEN", "SIXTHEEN", "SEVENTHEEN", "EIGHTHEEN", "NINETHEEN" };
    static readonly string[] Hundreds =
    { "", "ONE", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

    static void Main()
    {
        Console.Write("Enter a number [0;999]: ");

        int number = int.Parse(Console.ReadLine());

        if (number < 0 || number > 999)
        {
            throw new ArgumentOutOfRangeException("The number is out of range [0;999]...");
        }

        Console.Write("\n{0} -> ", number);
        Console.WriteLine(GetHundreds(number) + GetDecimals(number) + GetUnits(number) + Environment.NewLine);

        Console.Write("Press [SPACE] to print numbers from 0 - > 120 ");
        if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
        {
            Console.WriteLine("\n");
            for (number = 0; number <= 120; number++)
            {
                Console.Write("{0} -> ", number);
                Console.WriteLine(GetHundreds(number) + GetDecimals(number) + GetUnits(number));
            }
        }

        Console.WriteLine("\n");
    }

    private static string GetHundreds(int number)
    {
        if (number >= 100)
        {
            return string.Format("{0} HUNDRED", Hundreds[number / 100]);
        }

        return string.Empty;
    }

    private static string GetDecimals(int number)
    {
        if (number > 9 && number < 20)
        {
            return Decimals[number % 10 + 1];
        }
        else if (number % 100 >= 10 && number % 100 <= 19)
        {
            if (number / 100 > 0)
                return string.Format(" AND {0}", Decimals[Math.Abs(10 - number % 100) + 1]);
            else
                return Decimals[number / 10 % 10];
        }
        else if (number > 100 && number % 100 != 0 && number / 10 % 10 != 0)
        {
            return string.Format(" AND {0}", Hundreds[number / 10 % 10]);
        }
        else
        {
            return string.Format("{0}", Hundreds[number / 10 % 10]);
        }
    }

    private static string GetUnits(int number)
    {
        if (number < 10)
        {
            return string.Format("{0}", Units[number % 10 + 1]);
        }
        else if (number / 10 % 10 >= 2 && number <= 100 && number % 10 != 0)
        {
            return string.Format(" {0}", Units[number % 10 + 1]);
        }
        else if (number > 100 && number / 10 % 10 >= 2 && number % 10 != 0)
        {
            return string.Format(" {0}", Units[number % 10 + 1]);
        }
        else if (number > 100 && number % 100 < 10 && number % 10 != 0)
        {
            return string.Format(" AND {0}", Units[number % 10 + 1]);
        }

        return string.Empty;
    }
}