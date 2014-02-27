using System;

namespace CodingPractice.Heap
{
    public abstract class Heap : IPriorityQueue
    {
        protected IComparable[] elements;
        protected int lastIndex;
        protected int maxIndex;


        protected Heap()
        {
            elements = new IComparable[Int16.MaxValue];
            lastIndex = -1;
            maxIndex = Int16.MaxValue - 1;
        }

        #region Implementation of IPriorityQueue

        public void enqueue(IComparable item)
        {
            if (lastIndex == maxIndex)
                throw new Exception("Priority queue is full");
            lastIndex = lastIndex + 1;
            reheapUp(item);
        }

        public IComparable dequeue()
        {
            if (lastIndex == -1)
                throw new Exception("Priority queue is empty");
            IComparable hold = elements[0]; // element to be dequeued
            IComparable toMove = elements[lastIndex]; //item to reheap down
            lastIndex = lastIndex - 1;
            reheapDown(toMove);
            return hold;
        }

        public bool isEmpty()
        {
            return (lastIndex == -1);
        }

        public bool isFull()
        {
            return (lastIndex == maxIndex);
        }

        #endregion

        protected void reheapDown(IComparable item)
        {
            int hole = 0; //current index of hole
            int newhole; //new location of hole

            newhole = newHole(hole, item);
            while (hole != newhole)
            {
                elements[hole] = elements[newhole]; // move element up
                hole = newhole; // move hole down
                newhole = newHole(hole, item); //get next hole
            }

            elements[hole] = item; //fill final hole with item
        }

        protected abstract void reheapUp(IComparable item);
        protected abstract int newHole(int hole, IComparable item);
    }
}