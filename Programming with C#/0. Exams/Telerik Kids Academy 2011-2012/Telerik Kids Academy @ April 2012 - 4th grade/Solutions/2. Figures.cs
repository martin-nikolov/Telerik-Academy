using System;

class Figures
{
    // Our figure is:
    //
    //            d
    //   __________________
    //   |                 |\  
    //   |                 | \ b           
    // h |               c |  \
    //   |                 |  /
    //   |                 | / a
    //   |_________________|/
    //
    // minPerimeter = h + |h - c| + (2 * d) + a + b
    //
    // We want side 'c' to be longest in triangle ABC
    //
    static void Main()
    {
        int a, b, c, d, h, minPerimeter = 0, swap = 0;

        string lineReader = Console.ReadLine();
        string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        a = int.Parse(tokens[0]);
        b = int.Parse(tokens[1]);
        c = int.Parse(tokens[2]);
        d = int.Parse(tokens[3]);
        h = int.Parse(tokens[4]);

        if (a > b)
        {
            swap = a; a = b; b = swap;
        }

        if (b > c)
        {
            swap = b; b = c; c = swap;
        }

        if (a > b)
        {
            swap = a; a = b; b = swap;
        }

        if (d > h)
        {
            swap = d; d = h; h = swap;
        }

        minPerimeter = (h + Math.Abs(h - c) + (2 * d) + a + b);

        Console.WriteLine(minPerimeter);
    }
}