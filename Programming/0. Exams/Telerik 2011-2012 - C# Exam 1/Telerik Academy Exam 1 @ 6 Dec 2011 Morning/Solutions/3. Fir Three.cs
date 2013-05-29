using System;
using System.Linq;

class FirThree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int rocks = 1;
        int dots = n - 2;

        for (int i = 0; i < n; i++)
        {
            Console.Write(new string('.', dots));
            Console.Write(new string('*',rocks));
            Console.WriteLine(new string('.', dots));
            rocks += 2; dots -= 1;

            if (i == n - 2)
            {
                rocks = 1; dots = n - 2;
            }
        }
    }
}