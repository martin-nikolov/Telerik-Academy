using System;
using System.Linq;
using System.Collections.Generic;

class SpecialValue
{
    static int specialValue = 0;

    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        List<int[]> numbers = new List<int[]>();

        for (int i = 0; i < rows; i++)
            numbers.Add(Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToArray());

        for (int i = 0; i < numbers[0].Length; i++)
        {
            int nextIndex = numbers[0][i], nextRow = 1 % numbers.Count, steps = 1;

            while (true)
            {
                if (nextIndex < 0)
                {
                    int value = steps + Math.Abs(nextIndex);
                    if (value > specialValue) specialValue = value;
                    break;
                }
                else
                {
                    nextIndex = numbers[nextRow][nextIndex];
                    nextRow = (nextRow + 1) % numbers.Count;
                    steps++;
                }
            }
        }

        Console.WriteLine(specialValue);
    }
}
