using System;
using System.Linq;

class Tubes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int wantedTubes = int.Parse(Console.ReadLine());
        long[] sizes = new long[n];

        for (int i = 0; i < n; i++) sizes[i] = long.Parse(Console.ReadLine());

        long start = 1, end = sizes.Max(), answer = 0;

        while (start <= end)
        {
            long tubes = 0, middle = (start + end) / 2;

            for (int i = 0; i < n; i++) tubes += sizes[i] / middle;

            if (tubes < wantedTubes)
            {
                end = middle - 1;
            }
            else if (tubes >= wantedTubes)
            {
                answer = middle;
                start = middle + 1;
            }
        }

        Console.WriteLine(answer);
    }
}