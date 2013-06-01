using System;
using System.Linq;

class Frac
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        string[] tokens = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int a = int.Parse(tokens[0]);
        int b = int.Parse(tokens[1]);

        while (a != b)
        {
            if (a > b)
                a -= b;
            else
                b -= a;
        }

        Console.WriteLine("{0} {1}", int.Parse(tokens[0]) / a, int.Parse(tokens[1]) / a);
    }
}