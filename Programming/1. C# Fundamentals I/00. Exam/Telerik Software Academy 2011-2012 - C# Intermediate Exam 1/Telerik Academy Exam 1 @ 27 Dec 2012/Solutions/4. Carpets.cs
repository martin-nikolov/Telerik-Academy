using System;
using System.Linq;

public class Carpets
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char leftSide = '/';
        char rightSide = '\\';

        int rombStart = n / 2 - 1;
        int rombEnd = n / 2;

        for (int row = 0; row < n; row++)
        {
            if(row == n/2)
            {
                leftSide = '\\';
                rightSide = '/';

                rombStart = 0;
                rombEnd = n - 1;
            }

            Console.Write(new string('.', rombStart));
            int rombCells = n - (2 * rombStart);
            for (int col = 0; col < rombCells; col++)
            {
                if (col < rombCells / 2)
                    Console.Write(col % 2 == 0 ? leftSide : ' ');
                else
                    Console.Write(col % 2 != 0 ? rightSide : ' ');
            }
            Console.WriteLine(new string('.', rombStart));

            if (row < n / 2)
            {
                rombStart--;
                rombEnd++;
            }
            else
            {
                rombStart++;
                rombEnd--;
            }
        }
    }
}