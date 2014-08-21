/*
 * 10. We are given N and M and the following operations:
 * N = N+1
 * N = N+2
 * N = N*2
 * 
 * Write a program, which finds the shortest subsequence from
 * the operations, which starts with N and ends with M. 
 * Use queue.
 * 
 * Example: N = 5, M = 16
 * Subsequence: 5 -> 7 -> 8 -> 16
 */

namespace PathFinder
{
    using System;
    using System.Linq;
    using PathFinder.PrintStrategy;

    public class AllPathsBetweenTwoPointsEntryPoint
    {
        public static void Main()
        {
            int startValue = 5;
            int endValue = 16;

            var pathFinder = new AllPathsBetweenTwoPointsFinder();
            pathFinder.FindAllPaths(startValue, endValue);
            pathFinder.PrintResult(new SimplePathPrinter());
        }
    }
}