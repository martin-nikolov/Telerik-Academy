using System;
using System.Linq;

class Nice
{
    static void Main()
    {
        string number = Console.ReadLine();

        for (int i = 0; i < number.Length - 1; i++)
        {
            int sum = 0;
            for (int j = i + 1; j < number.Length; j++)
            {
                sum += number[j] - 48;
            }

            if (sum > number[i] - 48)
            {
                Console.WriteLine("NO");
                return;
            }
        }

        Console.WriteLine("YES");
    }
}