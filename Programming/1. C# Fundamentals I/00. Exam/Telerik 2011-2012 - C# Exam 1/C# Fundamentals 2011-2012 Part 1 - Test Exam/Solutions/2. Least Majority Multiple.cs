using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        byte a = byte.Parse(Console.ReadLine());
        byte b = byte.Parse(Console.ReadLine());
        byte c = byte.Parse(Console.ReadLine());
        byte d = byte.Parse(Console.ReadLine());
        byte e = byte.Parse(Console.ReadLine());

        int dividerCount = 0;

        for (int number = 4; number <= a * b * c; number++)
        {
            dividerCount = 0;

            if(number % a == 0)
            {
                dividerCount++;
            }

            if (number % b == 0)
            {
                dividerCount++;
            }

            if (number % c == 0)
            {
                dividerCount++;
            }

            if (number % d == 0)
            {
                dividerCount++;
            }

            if (number % e == 0)
            {
                dividerCount++;
            }

            if(dividerCount >= 3)
            {
                Console.WriteLine(number);
                break;
            }
        }
    }
}