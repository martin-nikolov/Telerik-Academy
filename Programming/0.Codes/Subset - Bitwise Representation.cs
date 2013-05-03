using System;

class Program
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] nums = new long[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = long.Parse(Console.ReadLine());
        }
        int maxI = 1;
        for (int i = 1; i <= n; i++)
        {
            maxI *= 2;
        }
        maxI -= 1;
        int count = 0;
        for (int i = 1; i <= maxI; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < n; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum += nums[j];
                }
            }
            if (currentSum == s)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}