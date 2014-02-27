using System;
using System.Linq;

namespace CodingPractice.Sorts
{
    public static class MergeSort
    {
        private static int[] values;
        private static int SIZE;

        public static void run()
        {
            values = new[] {24, 5, 45, 56};
            SIZE = values.Count();
            mergeSort(0, SIZE - 1);

            Console.WriteLine(string.Join(",", values));
        }


        private static void mergeSort(int first, int last)
        {
            if (first < last)
            {
                int middle = (first + last)/2;
                mergeSort(first, middle);
                mergeSort(middle + 1, last);
                merge(first, middle, middle + 1, last);
            }
        }

        private static void merge(int leftFirst, int leftLast, int rightFirst, int rightLast)
        {
            var tempArr = new int[SIZE]; // requires additional space to perform sorting.
            int index = leftFirst;
            int saveFirst = leftFirst; //this is very IMP.

            while ((leftFirst <= leftLast) && (rightFirst <= rightLast)) //core logic of comparing two elements
            {
                if (values[leftFirst] < values[rightFirst])
                {
                    tempArr[index] = values[leftFirst]; // this tells what position should the element be inserted
                    leftFirst++;
                }

                else
                {
                    tempArr[index] = values[rightFirst];
                    rightFirst++;
                }
                index++;
            }

            while (leftFirst <= leftLast) // copy back remaning data from left array
            {
                tempArr[index] = values[leftFirst];
                leftFirst++;
                index++;
            }

            while (rightFirst <= rightLast) // copy back remaining data from right array
            {
                tempArr[index] = values[rightFirst];
                rightFirst++;
                index++;
            }


            for (index = saveFirst; index <= rightLast; index++) //copy back to original array
                values[index] = tempArr[index];
        }
    }
}