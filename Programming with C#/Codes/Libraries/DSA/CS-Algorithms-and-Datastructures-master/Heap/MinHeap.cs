using System;

namespace CodingPractice.Heap
{
    public class MinHeap : Heap
    {
        #region Overrides of Heap

        protected override void reheapUp(IComparable item)
        {
            int hole = lastIndex; // initial insertion location

            while (hole > 0 && item.CompareTo(elements[(hole - 1)/2]) < 0) //MIN HEAP
                // if hole is not the root and item is greater than its parent value
            {
                elements[hole] = elements[(hole - 1)/2]; // move parent to hole 
                hole = (hole - 1)/2; // move hole up
            }

            elements[hole] = item; // place item into final hole.
        }


        protected override int newHole(int hole, IComparable item)
        {
            int left = (hole*2) + 1; //left child
            int right = (hole*2) + 2; //right child

            if (left > lastIndex)
                return hole; // hole has no childerns
            if (left == lastIndex) // hole has left child only
                if (item.CompareTo(elements[left]) > 0)
                    return left; //item is less than left child
                else
                    return hole; // item  >= right child
            if (elements[left].CompareTo(elements[right]) > 0) // left child > right child
                if (elements[right].CompareTo(item) > 0)
                    return hole; // right child <= item
                else
                    return right; // item < right child

            if (elements[left].CompareTo(item) > 0)
                return hole; // left child <= item
            else
                return left; // item < left child
        }

        #endregion

        public void changeRoot(IComparable x)
        {
            IComparable root = elements[0];
            if (root.CompareTo(x) < 0)
            {
                dequeue();
                enqueue(x);
            }
        }
    }
}