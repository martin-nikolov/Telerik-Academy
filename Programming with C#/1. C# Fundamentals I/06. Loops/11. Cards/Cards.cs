/*
* 11. Write a program that prints all possible cards from a standard
* deck of 52 cards (without jokers). The cards should be printed
* with their English names. Use nested for loops and switch-case.
*/

using System;
using System.Linq;

class Cards
{
    static void Main()
    {
        for (int color = 1; color <= 4; color++)
        {
            for (int sign = 2; sign <= 14; sign++)
            {
                switch (sign)
                {
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                    case 10: Console.Write("Ten"); break;
                    case 11: Console.Write("Knave"); break;
                    case 12: Console.Write("Queen"); break;
                    case 13: Console.Write("King"); break;
                    case 14: Console.Write("Ace"); break;
                    default: Console.Write("Error!"); break;
                }

                switch (color)
                {
                    case 1: Console.Write(" of Spades\n"); break;
                    case 2: Console.Write(" of Diamonds\n"); break;
                    case 3: Console.Write(" of Hearts\n"); break;
                    case 4: Console.Write(" of Clubs\n"); break;
                    default: Console.Write(" Error!\n"); break;
                }
            }
            Console.WriteLine();
        }
    }
}