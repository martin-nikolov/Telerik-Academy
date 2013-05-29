using System;
using System.Linq;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = x;
        int z = (x / 2) + 1;
        int dotsOutside = z - 1; 
        int dotsInside = 2 * x - 3;

        // First line of the logo
        Console.Write(new string('.', dotsOutside) + "*" + new string('.', dotsInside));
        Console.WriteLine("*" + new string('.', dotsOutside));

        int dotsCenter = dotsInside - 2;
        dotsOutside--;
        dotsInside = 1;

        // Draw all lines over the romb
        while (dotsOutside >= 0)
        {
            Console.Write(new string('.', dotsOutside) + "*" + new string('.', dotsInside) + "*");
            Console.Write(new string('.', dotsCenter));
            Console.WriteLine("*" + new string('.', dotsInside) + "*" + new string('.', dotsOutside));
            dotsCenter -= 2;
            dotsOutside--;
            dotsInside += 2;
        }

        dotsOutside = dotsInside;

        while (dotsCenter > 0)
        {
            Console.Write(new string('.', dotsOutside) + "*");
            Console.Write(new string('.', dotsCenter));
            Console.WriteLine("*" + new string('.', dotsOutside));
            dotsCenter -= 2;
            dotsOutside++;
        }

        // The algorith below makes the romb
        Console.WriteLine(new string('.', x + z - 2) + "*" + new string('.', x + z - 2));
        dotsOutside = x + z - 3; // Changes with 1 point every step
        dotsInside = 1; // Changes with 2 points every step
        for (int i = 0; i < x * 2 - 3; i++)
        {
            Console.Write(new string('.', dotsOutside) + "*");
            Console.Write(new string('.', dotsInside) + "*");
            Console.WriteLine(new string('.', dotsOutside));

            if (i < (x * 2 - 3) / 2)
            {
                dotsOutside--;
                dotsInside += 2;
            }
            else
            {
                dotsOutside++;
                dotsInside -= 2;
            }
        }
        Console.WriteLine(new string('.', x + z - 2) + "*" + new string('.', x + z - 2));
    }
}