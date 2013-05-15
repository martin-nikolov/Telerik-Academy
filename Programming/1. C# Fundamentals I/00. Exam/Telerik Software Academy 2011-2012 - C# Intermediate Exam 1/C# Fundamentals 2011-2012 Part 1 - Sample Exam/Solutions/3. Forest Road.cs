using System;
using System.Linq;

class ForestRoad
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            for (int j = 0; j < number; j++)
            {
                if (j == i)
                    Console.Write("*");
                else
                    Console.Write(".");
            }

            Console.WriteLine();
        }

        for (int i = number - 2; i >= 0; i--)
        {
            for (int j = 0; j < number; j++)
            {
                if (j == i)
                    Console.Write("*");
                else
                    Console.Write(".");
            }

            Console.WriteLine();
        }
    }
}