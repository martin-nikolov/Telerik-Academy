using System;
using System.Linq;
using System.Collections.Generic;

class QuadronacciRectangle
{
    static void Main()
    {
        List<long> nums = new List<long>();
        for (int i = 0; i < 4; i++)
        {
            nums.Add(long.Parse(Console.ReadLine()));
        }

        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        for (int i = 0; i < r * c; i++)
        {
            if (i >= 4) nums.Add(nums[i - 4] + nums[i - 3] + nums[i - 2] + nums[i - 1]);

            Console.Write((i + 1) % c == 0 ? nums[i] + "\n" : nums[i] + " ");
        }
    }
}