using System;
using System.Linq;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        byte binDigit = byte.Parse(Console.ReadLine());

        ushort numbers = ushort.Parse(Console.ReadLine());

        long[] allNumbers = new long[numbers];

        for (int i = 0; i < allNumbers.Length; i++)
        {
            allNumbers[i] = long.Parse(Console.ReadLine());
        }

        for (int i = 0; i < allNumbers.Length; i++)
        {
            byte digitCout = 0;

            while (allNumbers[i] != 0)
            {
                if ((allNumbers[i] & 1) == binDigit)
                    digitCout++;

                allNumbers[i] = allNumbers[i] >> 1;
            }

            Console.WriteLine(digitCout);
        }
    }
}