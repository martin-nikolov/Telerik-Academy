using System;

namespace CodingPractice.Sorts
{
    public static class HeapSort
    {
        private static IComparable[] elements;
        private static int SIZE;

        public static void run()
        {
            elements = new IComparable[] {25, 17, 36, 2, 3, 100, 1, 19, 7};
            SIZE = elements.Length;
            heapSort();
            foreach (int data in elements)
            {
                Console.WriteLine(data);
            }
        }

        private static void heapSort()
        {
            //convert array into a heap
            for (int index = SIZE/2 - 1; index >= 0; index--)
                heapify(elements[index], index, SIZE - 1);

            //sort the array
            for (int index = SIZE - 1; index >= 1; index--)
            {
                swap(0, index);
                heapify(elements[0], 0, index - 1);
            }
        }

        private static void heapify(IComparable item, int index, int lastIndex)
        {
            int hole = index; //current index of hole

            int newhole = newHole(hole, item, lastIndex);
            while (hole != newhole)
            {
                elements[hole] = elements[newhole]; // move element up
                hole = newhole; // move hole down
                newhole = newHole(hole, item, lastIndex); //get next hole
            }

            elements[hole] = item; //fill final hole with item
        }

        private static int newHole(int hole, IComparable item, int lastIndex)
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
            else 
                // left child >=right child
                if (elements[left].CompareTo(item) < 0)
                    // left child <= item
                    return hole;
                else
                    // item < left child
                    return left;
        }

        private static void swap(int i, int j)
        {
            IComparable temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}