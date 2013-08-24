using System;
using System.Linq;

class Lines
{
    static int splitsWithEqualSum = 0;
    static int totalSum = 0;
    static int width, height, depth;
    static int[, ,] cuboid;

    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(' ');
        width = int.Parse(tokens[0]);
        height = int.Parse(tokens[1]);
        depth = int.Parse(tokens[2]);
        cuboid = new int[width, height, depth];

        InitializeCuboid();

        SplitByWidth();
        SplitByHeight();
        SplitByDepth();

        Console.WriteLine(splitsWithEqualSum);
    }

    static void SplitByWidth()
    {
        int currentSum = 0;

        for (int w = 0; w < width - 1; w++)
        {
            for (int h = 0; h < height; h++)
                for (int d = 0; d < depth; d++) currentSum += cuboid[w, h, d];

            if (currentSum * 2 == totalSum) splitsWithEqualSum++;
        }
    }

    static void SplitByHeight()
    {
        int currentSum = 0;

        for (int d = 0; d < depth - 1; d++)
        {
            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++) currentSum += cuboid[w, h, d];

            if (currentSum * 2 == totalSum) splitsWithEqualSum++;
        }
    }

    static void SplitByDepth()
    {
        int currentSum = 0;

        for (int h = 0; h < height - 1; h++)
        {
            for (int d = 0; d < depth; d++)
                for (int w = 0; w < width; w++) currentSum += cuboid[w, h, d];

            if (currentSum * 2 == totalSum) splitsWithEqualSum++;
        }
    }

    static void InitializeCuboid()
    {
        for (int h = 0; h < height; h++)
        {
            int[] line = Console.ReadLine().Split(new string[] { " ", "|" }, StringSplitOptions.RemoveEmptyEntries).Select(ch => int.Parse(ch)).ToArray();
            int count = 0;
            totalSum += line.Sum();

            for (int d = 0; d < depth; d++)
                for (int w = 0; w < width; w++) cuboid[w, h, d] = line[count++];
        }
    }
}