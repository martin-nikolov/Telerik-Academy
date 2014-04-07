using System;
using System.Linq;

class Goro
{
    static void Main()
    {
        int[] numbers = new int[3];
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = int.Parse(Console.ReadLine());

        Array.Sort(numbers);

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            sum += numbers[2];

            if (numbers[2] >= 1) numbers[2]--;

            Array.Sort(numbers);
        }

        Console.WriteLine(sum);
    }
}