using System;
using System.Collections.Generic;
using System.Linq;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            numbers[i] = (int.MaxValue >> (31 - Convert.ToString(numbers[i], 2).Length)) & ReverseBinary(numbers[i]);
        }

        for (int j = 0; j < numbers.Length; j++)
            Console.WriteLine(numbers[j]);
    }

    static int ReverseBinary(int number)
    {
        Queue<int> bin = new Queue<int>();

        while (number != 0)
        {
            bin.Enqueue(number % 2);
            number /= 2;
        }

        while (bin.Count > 0)
        {
            number *= 2;
            number += bin.Dequeue();
        }

        return number;
    }
}