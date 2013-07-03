using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace LongestIncreasingRow
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();

        //Some Global Variables
        static int[] numArray = { 6, 6, 5, 4, 3, 2, 1, 3, 1, 2, 3, 4, 5, 6, 3, 2, 1, 2, 1, 2, 3 };
        static int totalSubSets = (int)Math.Pow(2, numArray.Length) - 1;

        static List<int>[] bestList = new List<int>[100];
        static List<int> currentList = new List<int>();

        static int bestLength = 0;
        static int currentIndex = 0;
        static int totalIncreasingRows = 0;

        static void Main(string[] args)
        {
            sw.Start();
            for (int i = 0; i < bestList.GetLongLength(0); i++)
                bestList[i] = new List<int>();

            GetSubSets();

            //Printing the best rows
            for (int i = 0; i < 100; i++)
            {
                if (bestList[i].Count == 0)
                    break;
                if (bestList[i].Count == bestLength)
                {
                    totalIncreasingRows++;
                    foreach (var item in bestList[i])
                        Console.Write("{0} ", item);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("The longest length: {0}", bestLength);
            Console.WriteLine("Total subsets: {0}", totalSubSets + 1);
            Console.WriteLine("Total increasing rows: {0}", totalIncreasingRows);
            Console.WriteLine("Lenght of Best List: {0}", bestList.GetLongLength(0));
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine("Total waste time: {0}", sw.Elapsed);
            Console.WriteLine("Total used memory: {0} bytes", GC.GetTotalMemory(true));
        }

        //Check if arr[i] >= arr[i+1]
        static bool BetterElements(List<int> currentList)
        {
            for (int i = 0; i < currentList.Count - 1; i++)
            {
                if (currentList[i] > currentList[i + 1])
                    return false;
            }
            return true;
        }

        //Search a subsets
        static void GetSubSets()
        {
            for (int i = totalSubSets; i >= 1; i--)
            //for (int i = 1; i <= totalSubSets; i++)
            {
                int currentLength = 0;

                for (int j = 0; j < numArray.Length; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        currentLength++;
                        currentList.Add(numArray[j]);
                    }
                }

                if (BetterElements(currentList) == true)
                {
                    if (currentLength >= bestLength)
                    {
                        bestLength = currentLength;

                        for (int h = 0; h < currentList.Count; h++)
                        {
                            bestList[currentIndex].Add(currentList[h]);
                        }
                        currentIndex++;
                    }
                }
                currentList.Clear();
            }
        }
    }
}