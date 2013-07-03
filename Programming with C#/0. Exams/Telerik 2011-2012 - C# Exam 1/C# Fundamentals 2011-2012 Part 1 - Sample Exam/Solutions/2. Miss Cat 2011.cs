using System;
using System.Linq;

class MissCat2011
{
    static void Main(string[] args)
    {
        int numberOfCats = int.Parse(Console.ReadLine());

        int[] pointCollector = new int[numberOfCats];
        int[] pointMatrix = new int[10];

        int mostPoint = 0;
        int indexOfCatWithMostPoint = 0;

        for (int i = 0; i < pointCollector.Length; i++)
        {
            pointCollector[i] = int.Parse(Console.ReadLine());
            pointMatrix[pointCollector[i] - 1]++;

            if (pointMatrix[pointCollector[i] - 1] > mostPoint)
            {
                mostPoint = pointMatrix[pointCollector[i] - 1];
                indexOfCatWithMostPoint = pointCollector[i];
            }
        }

        Console.WriteLine(indexOfCatWithMostPoint);
    }
}