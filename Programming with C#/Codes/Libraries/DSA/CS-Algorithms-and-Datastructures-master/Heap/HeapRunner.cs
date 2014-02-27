using System;

namespace CodingPractice.Heap
{
    public static class HeapRunner
    {
        public static void run()
        {
            IPriorityQueue maxHeap = new tempHeap();
            maxHeap.enqueue(5);
            maxHeap.enqueue(10);
            maxHeap.enqueue(9);
            maxHeap.enqueue(15);

            //Console.WriteLine(maxHeap.dequeue());

            //IPriorityQueue minHeap = new MinHeap();
            //minHeap.enqueue(5);
            //minHeap.enqueue(10);
            //minHeap.enqueue(9);
            //minHeap.enqueue(15);

            //Console.WriteLine(minHeap.dequeue());
        }
    }
}