using System;

class FighterAttack
{
    public static void Main()
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

        int dotsX = fx + d;
        int dotCenterY = fy; // 100%
        int dotUpY = fy + 1; // 50%
        int dotDownY = fy - 1; // 50%
        int dotRightY = fy; // x = dotsX - 1; ->= 75%

        int damage = 0;

        if (maxX >= dotsX && minX <= dotsX && maxY >= dotCenterY && minY <= dotCenterY)
        {
            damage += 100;
        }
        if (maxX >= dotsX + 1 && minX <= dotsX + 1 && maxY >= dotRightY && minY <= dotRightY)
        {
            damage += 75;
        }
        if (maxX >= dotsX && minX <= dotsX && maxY >= dotUpY && minY <= dotUpY)
        {
            damage += 50;
        }
        if (maxX >= dotsX && minX <= dotsX && maxY >= dotDownY && minY <= dotDownY)
        {
            damage += 50;
        }

        Console.WriteLine("{0}%", damage);
    }
}