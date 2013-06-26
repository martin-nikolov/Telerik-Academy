using System;
using System.Linq;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int pointOutside = n / 2 - 1;
        int pointInside = 2;

        Console.WriteLine(new string('.', pointOutside) + "##" + new string('.', pointOutside)); 
        pointOutside--;

        for (int i = 0; i < n / 2 - 1; i++, pointInside += 2, pointOutside--)
            WriteCurrentFireLine(pointOutside, pointInside);

        pointOutside = 0; pointInside -= 2;

        for (int i = 0; i < n / 4; i++, pointInside -= 2, pointOutside++)
            WriteCurrentFireLine(pointOutside, pointInside);

        Console.WriteLine(new string('-', n));
        pointOutside = 0;

        for (int i = 0; i < n / 2; i++, pointOutside++)
        {
            Console.Write(new string('.', pointOutside));

            for (int j = 0; j < n / 2 - pointOutside; j++)
                Console.Write("\\");

            for (int j = 0; j < n / 2 - pointOutside; j++)
                Console.Write("/");

            Console.WriteLine(new string('.', pointOutside));
        }
    }
  
    private static void WriteCurrentFireLine(int pointOutside, int pointInside)
    {
        Console.Write(new string('.', pointOutside) + "#");
        Console.Write(new string('.', pointInside) + "#");
        Console.WriteLine(new string('.', pointOutside));
    }
}