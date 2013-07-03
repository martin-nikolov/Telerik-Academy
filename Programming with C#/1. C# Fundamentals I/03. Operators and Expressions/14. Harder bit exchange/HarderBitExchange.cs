/*
* 14. Write a program that exchanges bits {p, p+1, …, p+k-1)
* with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
*/

using System;
using System.Linq;

class HarderBitExchange
{
    private static void PrintBinaryNumber(byte[] numberToBinary)
    {
        for (int j = numberToBinary.Length - 1; j >= 0; j--)
        {
            Console.Write(numberToBinary[j]);

            if ((j + 4) % 4 == 0)
                Console.Write(" ");
        }
    }

    static void Main(string[] args)
    {
        uint number = 1073709056;
        byte p = 1, q = 15, steps = 14; // steps = k

        byte[] numberToBinary = new byte[32];

        // Initialize array (number to binary), every cell contains 0 or 1
        for (int i = 0; i < numberToBinary.Length; i++)
        {
            numberToBinary[i] = (byte)(number % 2);
            number = number / 2;
        }

        Console.Write("Step 0   -> ");
        PrintBinaryNumber(numberToBinary);
        Console.WriteLine();

        for (int i = 0; i < steps; i++)
        {
            byte temp = numberToBinary[p];
            numberToBinary[p] = numberToBinary[q];
            numberToBinary[q] = temp;
            p++;
            q++;
            
            // Follow the steps
            Console.Write("Step {0,-3} -> ", i + 1);
            PrintBinaryNumber(numberToBinary);
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
    }
}