using System;
using System.Linq;

namespace CodingPractice.Sorts
{
    public static class QuickSort
    {
        private static int[] values;
        private static int SIZE;

        public static void run()
        {
            values = new[] {24, 5, 45, 8, 12, 6};
            SIZE = values.Count();
            quickSort(0, SIZE - 1);
            Console.WriteLine(string.Join(",", values));
        }

        /// <summary>
        /// helper method to sort a given ip array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] sort(int[] arr)
        {
            values = arr;
            SIZE = values.Count();
            quickSort(0, SIZE - 1);
            return values;
        }

        private static void quickSort(int first, int last)
        {
            if (first >= last) return;
            int splitPoint = split(first, last);
            quickSort(first, splitPoint - 1); // always -1 since splitpoint is at the right place already
            quickSort(splitPoint + 1, last); // always +1 since splitpoint is at the right place already
        }

        private static int split(int first, int last)
        {
            int splitValue = values[first];
            int saveF = first;

            first++; // increment since first value = split value
            do
            {
                bool onCorrectSide = true;
                while (onCorrectSide)
                {
                    if (values[first] > splitValue)
                    {
                        onCorrectSide = false;
                    }
                    else
                    {
                        first++;
                        onCorrectSide = (first <= last);
                    }
                }
                onCorrectSide = (first <= last);

                while (onCorrectSide)
                {
                    if (values[last] < splitValue)
                    {
                        onCorrectSide = false;
                    }
                    else
                    {
                        last--;
                        onCorrectSide = (first <= last);
                    }
                }

                if (first < last)
                {
                    swap(first, last);
                    first++;
                    last--;
                }
            } while (first <= last);

            swap(saveF, last); // very important.. always swap saveF with last element which is less than saveF
            return last; // that last element is the splitting point.. ie last has been placed at its correct place
        }

        private static void swap(int first, int last)
        {
            int temp = values[first];
            values[first] = values[last];
            values[last] = temp;
        }
    }
}