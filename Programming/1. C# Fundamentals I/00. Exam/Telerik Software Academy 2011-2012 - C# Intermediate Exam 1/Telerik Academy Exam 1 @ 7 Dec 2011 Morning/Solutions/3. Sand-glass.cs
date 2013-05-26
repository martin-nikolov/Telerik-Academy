using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int dots = 0, rocks = n;

        for (int i = 0; i < n; i++)
        {
            Console.Write(new string('.', dots));
            Console.Write(new string('*', rocks));
            Console.WriteLine(new string('.', dots));

            if (i < n / 2)
            {
                dots++; rocks -= 2;
            }
            else
            {
                dots--; rocks += 2;
            }
        }
    }
}