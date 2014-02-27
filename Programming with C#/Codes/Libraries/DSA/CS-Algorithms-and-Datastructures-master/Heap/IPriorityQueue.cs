using System;

namespace CodingPractice.Heap
{
    public interface IPriorityQueue
    {
        void enqueue(IComparable item);
        IComparable dequeue();
        bool isEmpty();
        bool isFull();
    }
}