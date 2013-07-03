/*
* 12. Write a program that reads from the console a positive
* integer number N (N < 20) and outputs a matrix like the following:

* Example: 
* 1 2 3 4
* 2 3 4 5
* 3 5 6 7
* 4 5 6 7
*/

using System;
using System.Linq;

class MatrixFirstVariant
{
    static void Main()
    {
        Console.Write("Enter a number (0 < N < 20): ");
        byte n = byte.Parse(Console.ReadLine());

        Console.WriteLine();
        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col <= row+n-1; col++)
            {
                Console.Write("{0,3}", col);
            }

            Console.WriteLine();
        }
        Console.WriteLine();
    }
}