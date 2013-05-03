using System;

class Program
{
    static void Main()
    {
        string num = Console.ReadLine();
        string[] tokens = num.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int rows = int.Parse(tokens[0]);
        int cols = int.Parse(tokens[1]);

        int[,] array = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            num = Console.ReadLine();
            tokens = num.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < cols; col++)
            {
                array[row, col] = int.Parse(tokens[col]);
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0} ", array[row, col]);
            }
            Console.WriteLine();
        }
    }
}