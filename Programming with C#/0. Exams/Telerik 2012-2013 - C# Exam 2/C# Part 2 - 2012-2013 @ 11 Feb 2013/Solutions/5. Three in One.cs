using System;
using System.Collections.Generic;
using System.Linq;

class ThreeInOne
{
    static void Main()
    {
        SolveTask1();

        SolveTask2();

        SolveTask3();
    }

    static void SolveTask1()
    {
        int[] points = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToArray();
        Dictionary<int, int> occurs = new Dictionary<int, int>();

        for (int i = 0; i < points.Length; i++)
            if (!occurs.ContainsKey(points[i]) && points[i] <= 21) occurs.Add(points[i], 1);
            else if (points[i] <= 21) occurs[points[i]]++;

        occurs = occurs.OrderByDescending(i => i.Key).ToDictionary(k => k.Key, k => k.Value);

        Console.WriteLine(occurs.ElementAt(0).Value == 1 ? Array.IndexOf(points, occurs.ElementAt(0).Key) : -1);
    }

    static void SolveTask2()
    {
        List<int> sizes = Console.ReadLine().Split(',').Select(ch => int.Parse(ch)).ToList();
        int f = int.Parse(Console.ReadLine());

        sizes.Sort();

        int index = sizes.Count - 1, bitesOfCakeCount = 0;

        while (index >= 0)
        {
            bitesOfCakeCount += sizes[index];
            index -= f + 1;
        }

        Console.WriteLine(bitesOfCakeCount);
    }

    static void SolveTask3()
    {
        int[] coins = Console.ReadLine().Split(' ').Select(ch => int.Parse(ch)).ToArray();

        int steps = 0;

        int g1 = coins[0], s1 = coins[1], b1 = coins[2];
        int g2 = coins[3], s2 = coins[4], b2 = coins[5];

        while (g2 > g1)
        {
            g1++;
            s1 -= 11;
            steps++;
        }

        while (s2 > s1)
        {
            if (g1 > g2)
            {
                g1--;
                s1 += 9;
            }
            else
            {
                s1++;
                b1 -= 11;   
            }

            steps++;
        }

        while (b2 > b1)
        {
            if (s1 > s2)
            {
                s1--;
                b1 += 9;
            }
            else if (g1 > g2)
            {
                g1--;
                s1 += 9;
            }
            else
            {
                Console.WriteLine(-1);
                return;
            } 
            
            steps++;
        }

        Console.WriteLine(steps);
    }
}