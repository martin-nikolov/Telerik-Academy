using System;
 
class Problem5FallDown
{
    static void Main()
    {
        int[] numbers = new int[8];
 
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
 
        for (int z = numbers.Length - 1; z >= 1; z--)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((numbers[z] & (1 << i)) == 0)
                {
                    for (int y = z - 1; y >= 0; y--)
                    {
                        if ((numbers[y] >> i & 1) == 1)
                        {
                            numbers[z] = numbers[z] | (1 << i);
                            numbers[y] = numbers[y] & ~(1 << i);
                            break;
                        }
                     }
                }
            }
        }
 
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}