using System;
using System.Linq;

class TwoFourEight
{
    static void Main()
    {
        int A = int.Parse(Console.ReadLine());
        int B = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());

        long result = 0;

        switch (B)
        {
            case 2: result = (long)A % C; break;
            case 4: result = (long)A + C; break;
            case 8: result = (long)A * C; break;
        }

        Console.WriteLine(result % 4 == 0 ? result / 4 : result % 4);
        Console.WriteLine(result);
    }
}