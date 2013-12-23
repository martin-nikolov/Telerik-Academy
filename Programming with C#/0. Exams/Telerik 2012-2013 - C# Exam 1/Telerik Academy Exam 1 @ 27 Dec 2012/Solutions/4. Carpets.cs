using System;

class Carpets
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());

        int middle = h / 2 - 1;
        int points = h / 2 - 1;
        int whiteSpaces = 0;

        char left = '/';
        char right = '\\';

        for (int i = 0; i < h; i++)
        {
            Console.Write(new string('.', points));
            Console.Write(left);

            for (int j = 0; j < whiteSpaces; j++)
            {
                if (j < whiteSpaces / 2)
                    Console.Write((j & 1) != 0 ? left : ' ');
                else
                    Console.Write((j & 1) == 0 ? right : ' ');           
            }

            Console.Write(right);
            Console.Write(new string('.', points));

            Console.WriteLine();

            if (i < middle)
            {
                --points;
                whiteSpaces += 2;
            }
            else if (i == middle)
            {
                left = '\\';
                right = '/';
            }
            else if (i > middle)
            {
                ++points;
                whiteSpaces -= 2;
            }
        }
    }
}