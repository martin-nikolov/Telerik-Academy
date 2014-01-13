using System;

class QuickSortAlgorithm
{
    static void Main()
    {
        TestRunner();
        
    }

    static void TestRunner()
    {
        Array<int> numbers = new Array<int>(1, -2, 3, -4, 5, -6, 7, -8, 9, -10);
        Array<string> symbols = new Array<string>("b", "d", "c", "a", "f", "w", "z");
        Array<char> letters = new Array<char>('z', 'b', 'd', 'c', 'w', 'a', 'f');
        Array<byte> empty = new Array<byte>();

        numbers.Sort();
        symbols.Sort();
        letters.Sort();
        empty.Sort();

        numbers.PrintElementsByDescending();
        numbers.PrintElementsByAscending();

        symbols.PrintElementsByDescending();
        symbols.PrintElementsByAscending();

        letters.PrintElementsByDescending();
        letters.PrintElementsByAscending();

        empty.PrintElementsByDescending();
        empty.PrintElementsByAscending();
    }

    static void QuickSort<T>(T[] sortArray, int leftIndex, int rightIndex) where T : IComparable<T>
    {
        /* QUICKSORT(A,p,r)
        1  if p < r
        2      then q  PARTITION(A,p,r)
        3           QUICKSORT(A,p,q)
        4           QUICKSORT(A,q + 1,r)*/
        if (leftIndex >= rightIndex)
            return;

        T frontier;
        int leftPointer = leftIndex;
        int rightPointer = rightIndex;

        // 1. Pick a pivot value somewhere in the middle.
        frontier = sortArray[(leftIndex + rightIndex) / 2];

        // 2. Loop until pointers meet on the pivot.
        while (leftPointer <= rightPointer)
        {
            // 3. Find a larger value to the right of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[leftPointer].CompareTo(frontier) < 0)
                leftPointer++;

            // 4. Find a smaller value to the left of the pivot.
            //    If there is non we end up at the pivot.
            while (sortArray[rightPointer].CompareTo(frontier) > 0)
                rightPointer--;

            // 5. Check if both pointers are not on the pivot.
            if (leftPointer <= rightPointer)
            {
                // 6. Swap both values to the right side.
                T swap = sortArray[leftPointer];
                sortArray[leftPointer] = sortArray[rightPointer];
                sortArray[rightPointer] = swap;

                leftPointer++;
                rightPointer--;
            }
        }

        // Here's where the pivot value is in the right spot

        // 7. Recursively call the algorithm on the unsorted array
        //    to the left of the pivot (if exists).
        if (rightPointer > leftIndex)
            QuickSort(sortArray, leftIndex, rightPointer);

        // 8. Recursively call the algorithm on the unsorted array
        //    to the right of the pivot (if exists).
        if (leftPointer < rightIndex)
            QuickSort(sortArray, leftPointer, rightIndex);
        // 9. The algorithm returns when all sub arrays are sorted.
    }

    public class Array<T> where T : IComparable<T>
    {
        private readonly T[] array;

        public Array(params T[] array)
        {
            this.array = array;
        }

        public void Sort()
        { 
            T[] temp = new T[array.Length];
            QuickSort(array, 0, array.Length - 1);     
        }

        public void PrintElementsByDescending()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("No items in array for sorting!");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public void PrintElementsByAscending()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("No items in array for sorting!");
                return;
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}