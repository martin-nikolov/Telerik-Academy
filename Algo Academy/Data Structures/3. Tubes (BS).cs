using System;
using System.Linq;

class Tubes
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int friendsCount = int.Parse(Console.ReadLine());

        int[] tubes = new int[N];

        for (int i = 0; i < N; i++) tubes[i] = int.Parse(Console.ReadLine());

        Console.WriteLine(FindMaximalLength(tubes, friendsCount));
    }
  
    static int FindMaximalLength(int[] tubes, int neededCount)
    {
        int min = 1, max = tubes.Max(), middle, count, answer = -1;

        while (min <= max)
        {
            middle = (min + max) / 2;
            count = 0;

            for (int i = 0; i < tubes.Length; i++) count += tubes[i] / middle;

            if (count < neededCount)
            {
                max = middle - 1;
            }
            else if (count >= neededCount)
            {
                min = middle + 1;
                answer = middle;
            }
        }

        return answer;
    }
}