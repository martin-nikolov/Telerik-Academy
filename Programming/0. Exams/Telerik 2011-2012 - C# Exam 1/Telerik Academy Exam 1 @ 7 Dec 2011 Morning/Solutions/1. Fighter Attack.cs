using System;
using System.Linq;

class FighterAttack
{
    static void Main()
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int minX = Math.Min(px1, px2);
        int minY = Math.Min(py1, py2);
        int maxX = Math.Max(px1, px2);
        int maxY = Math.Max(py1, py2);

        int dotX = fx + d;
        int dotCenterY = fy; // 100%
        int dotUpY = fy + 1; // 50%
        int dotDownY = fy - 1; // 50%
        int dotRightY = fy; // x = dotsX + 1; -> 75%

        int damage = 0;

        if (dotX >= minX && dotX <= maxX)
        {
            if (dotCenterY >= minY && dotCenterY <= maxY)
                damage += 100;

            if (dotUpY >= minY && dotUpY <= maxY)
                damage += 50;

            if (dotDownY >= minY && dotDownY <= maxY)
                damage += 50;
        }

        if (dotX + 1 >= minX && dotX + 1 <= maxX)
        {
            if (dotRightY >= minY && dotRightY <= maxY)
                damage += 75;
        }

        Console.WriteLine(damage + "%");
    }
}