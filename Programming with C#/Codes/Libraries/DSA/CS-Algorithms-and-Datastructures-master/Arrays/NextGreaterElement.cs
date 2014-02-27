using System;
using System.Collections.Generic;

namespace CodingPractice
{
    public static class NextGreaterElement
    {
        private static int[] arr;
        private static int SIZE;

        public static void run()
        {
            arr = new[] {11, 3, 13, 21};
            SIZE = arr.Length;
            printNGE();
        }

        private static void printNGE()
        {
            var queue = new Queue<int>();
            int element;
            int next;

            queue.Enqueue(arr[0]); // to start .. push first element into array

            //stack always holds element data.. the data which is we compare with next element

            for (int i = 1; i < SIZE; i++) //start from 1 since 0th element is pushed into stack 
            {
                next = arr[i]; // get next element .. which will always be next = element + 1

                if (queue.Count > 0)
                {
                    element = queue.Dequeue();

                    while (element < next)
                    {
                        Console.WriteLine(string.Format("{0} --> {1}", element, next));
                        if (queue.Count == 0)
                            break;
                        element = queue.Dequeue();
                    }

                    if (element > next)
                    {
                        queue.Enqueue(element); // since element was bigger push that into stack for future match
                    }
                }

                queue.Enqueue(next); //push next .. so that next becomes element for next round.
            }

            while (queue.Count > 0) // remaning non matched data elements
            {
                Console.WriteLine(string.Format("{0} --> {1}", queue.Dequeue(), -1));
            }
        }
    }
}