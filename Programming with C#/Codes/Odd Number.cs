using System;

class Program
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        long number = 0;
        long odd = 0;

        for (long i = 1; i <= lines; i++)
        {
            number = long.Parse(Console.ReadLine());

            odd = number ^ odd;
        }
        Console.WriteLine(odd);
    }
}

// Output: 3 2 2 3 3 3 2
// 1) odd = 0000 0011
// 2) odd = 0000 0001
// 3) odd = 0000 0011
// 4) odd = 0000 0000
// 5) odd = 0000 0011
// 6) odd = 0000 0000
// 7) odd = 0000 0010
