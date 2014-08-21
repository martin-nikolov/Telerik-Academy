/*
 * 9.
 * We are given the following sequence:
 * S1 = N;
 * S2 = S1 + 1;
 * S3 = 2*S1 + 1;
 * S4 = S1 + 2;
 * S5 = S2 + 1;
 * S6 = 2*S2 + 1;
 * S7 = S2 + 2;
 * ...
 * 
 * Using the Queue<T> class write a program to print its first 50 members for given N.
 * Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    public class FindNextMembers
    {
        private static readonly Func<int, int>[] operations =
        {
            x => x + 1,
            x => 2 * x + 1,
            x => x + 2,
        };

        public static void Main()
        {
            Console.Write("N: ");
            var startupNumber = int.Parse(Console.ReadLine());

            Console.Write("Count: ");
            var count = int.Parse(Console.ReadLine());

            var calculatedMembers = CalculateNextMembers(startupNumber, count);
            Console.WriteLine(string.Join(", ", calculatedMembers));
        }

        public static IEnumerable<int> CalculateNextMembers(int startupNumber, int count)
        {
            var sequence = new AbstractDataStructures.Queue<int>(); // My implementation of Queue
            var result = new List<int>();

            sequence.Enqueue(startupNumber);
            result.Add(startupNumber);

            for (int i = 0; i < count; i++)
            {
                var member = sequence.Dequeue();
                var nextMembers = new List<int>();
            
                foreach (var operation in operations)
                {
                    nextMembers.Add(operation(member));
                }

                sequence.Enqueue(nextMembers[0]);
                sequence.Enqueue(nextMembers[1]);
                sequence.Enqueue(nextMembers[2]);

                result.AddRange(nextMembers);
            }

            return result;
        }
    }
}