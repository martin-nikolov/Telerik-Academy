using System;
using System.Linq;
using System.Text;

class KaspichaniaBoats
{
    static int dotsOutside, dotsBetweenStars, baseHeight;
    static StringBuilder boat = new StringBuilder();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int height = 6 + ((n - 3) / 2) * 3;
        baseHeight = height / 3;
        dotsOutside = n - 1;
        dotsBetweenStars = 0;

        BuildVertice(n);
        BuildBase(n);

        Console.Write(boat);
    }

    static void BuildVertice(int n)
    {
        boat.AppendLine(new string('.', n) + '*' + new string('.', n));
        BuildRows(n, true);
        boat.AppendLine(new string('*', 2 * n + 1));

        dotsOutside++;
        dotsBetweenStars--;
    }

    static void BuildBase(int n)
    {
        BuildRows(baseHeight, false);
        boat.AppendLine(new string('.', dotsOutside) + new string('*', n) + new string('.', dotsOutside));
    }

    static void BuildRows(int height, bool isVertice)
    {
        for (int i = 0; i < height - 1; i++,
         dotsBetweenStars += isVertice ? 1 : -1, dotsOutside += isVertice ? -1 : 1)
        {
            boat.Append(new string('.', dotsOutside));

            boat.Append('*' + new string('.', dotsBetweenStars));
            boat.Append('*' + new string('.', dotsBetweenStars) + '*');

            boat.AppendLine(new string('.', dotsOutside));
        }
    }
}