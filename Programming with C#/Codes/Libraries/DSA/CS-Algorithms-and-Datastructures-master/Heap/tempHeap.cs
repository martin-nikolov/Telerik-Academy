using System;

namespace CodingPractice.Heap
{
    public class tempHeap : IPriorityQueue
    {
        private readonly IComparable[] elements;
        private readonly int maxIndex;
        private int lastIndex;

        public tempHeap()
        {
            elements = new IComparable[Int16.MaxValue];
            lastIndex = -1;
            maxIndex = Int16.MaxValue;
        }

        #region Implementation of IPriorityQueue

        public void enqueue(IComparable item)
        {
            if (lastIndex == maxIndex)
                throw new InsufficientMemoryException("Heap is full");
            lastIndex += 1;
            reheapUp(item);
        }

        public IComparable dequeue()
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public bool isFull()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void reheapUp(IComparable item)
        {
            int hole = lastIndex;

            while (hole > 0 && item.CompareTo(elements[(hole - 1)/2]) > 0)
            {
                elements[hole] = elements[(hole - 1)/2] ; // move hole into its parent
                hole = (hole - 1)/2; // move hole up
            }

            elements[hole] = item;
        }
    }
}