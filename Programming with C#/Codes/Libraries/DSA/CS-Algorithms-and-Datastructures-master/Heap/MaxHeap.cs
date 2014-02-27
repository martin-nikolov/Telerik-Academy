using System;

namespace CodingPractice.Heap
{
    public class MaxHeap : Heap
    {
        protected override void reheapUp(IComparable item) //MAX HEAP
        {
            int hole = lastIndex; // initial insertion location.. always insert at last location

            while (hole > 0 && item.CompareTo(elements[(hole - 1)/2]) > 0)
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
                // hole has no childerns
                return hole;
            if (left == lastIndex) // hole has left child only
                if (item.CompareTo(elements[left]) < 0)
                    // item < left child
                    return left;
                else
                    // item  >= right child
                    return hole;
            // left child < right child
            if (elements[left].CompareTo(elements[right]) < 0)
                if (elements[right].CompareTo(item) < 0)
                    // right child <= item
                    return hole;
                else
                    // item < right child
                    return right;
            // left child >=right child
            if (elements[left].CompareTo(item) < 0)
                // left child <= item
                return hole;
            else
                // item < left child
                return left;
        }
    }
}