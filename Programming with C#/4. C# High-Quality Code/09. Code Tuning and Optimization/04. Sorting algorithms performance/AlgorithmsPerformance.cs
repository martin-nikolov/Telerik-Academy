/*
 * 4. * Write a program to compare the performance of insertion sort,
 * selection sort, quicksort for int, double and string values. 
 * Check also the following cases: random values, sorted values, 
 * values sorted in reversed order.
 */

namespace Performance
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Performance.Algorithms;

    /// <summary>
    /// How it works:
    ///     1) Test with no sorted random elements
    ///     2) Test with sorted ascending elements
    ///     3) Test with sorted descending elements
    ///     4) After each performance test - function AreSequencesEqual(arr1, arr2) is executed
    ///        to guarantee that all the arrays are correctly sorted
    /// </summary>
    internal class AlgorithmsPerformance
    {
        private static readonly Stopwatch sw = new Stopwatch();
        private const int Capacity = 10000; // test it with 10 elements

        static void Main()
        {
            PerformTestWithIntegers();
            PerformTestWithDoubles();
            PerformTestWithStrings();
        }
 
        private static void PerformTestWithIntegers()
        {
            Console.WriteLine("Random integers:");
            TestWithIntegers();

            Console.WriteLine("\nRandom sorted integers:");
            TestWithIntegers(areSorted: true);

            Console.WriteLine("\nRandom sorted integers in reversed order:");
            TestWithIntegers(areSorted: true, isReversed: true);
        }

        private static void PerformTestWithDoubles()
        {
            Console.WriteLine("\n-------------------------\n");
            Console.WriteLine("Random doubles:");
            TestWithDoubles();

            Console.WriteLine("\nRandom sorted doubles:");
            TestWithDoubles(areSorted: true);

            Console.WriteLine("\nRandom sorted doubles in reversed order:");
            TestWithDoubles(areSorted: true, isReversed: true);
        }

        private static void PerformTestWithStrings()
        {
            Console.WriteLine("\n-------------------------\n");
            Console.WriteLine("Random strings:");
            TestWithStrings();

            Console.WriteLine("\nRandom sorted strings:");
            TestWithStrings(areSorted: true);

            Console.WriteLine("\nRandom sorted strings in reversed order:");
            TestWithStrings(areSorted: true, isReversed: true);
        }

        private static void TestWithIntegers(bool areSorted = false, bool isReversed = true)
        {
            var randomIntegers = Utils.GetArrayWithRandomIntegers(Capacity);
            sw.Reset();

            if (areSorted)
            {
                Array.Sort(randomIntegers);
            }

            if (isReversed)
            {
                Array.Reverse(randomIntegers);
            }

            #region [Quicksort]

            var quickSortCollection = randomIntegers.ToList();

            sw.Start();
            new QuickSortAlgorithm<int>().Sort(quickSortCollection);
            sw.Stop();

            Console.WriteLine("QuickSort: " + sw.Elapsed);

            #endregion

            #region [Mergesort]

            var mergeSortCollection = randomIntegers.ToList();

            sw.Restart();
            new MergeSortAlgorithm<int>().Sort(mergeSortCollection);
            sw.Stop();

            Console.WriteLine("MergeSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Insertion sort]
            
            var insertionSortCollection = randomIntegers.ToList();
            
            sw.Restart();
            new InsertionSortAlgorithm<int>().Sort(insertionSortCollection);
            sw.Stop();
            
            Console.WriteLine("InsertionSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Selection sort]
            
            var selectionSortCollection = randomIntegers.ToList();
            
            sw.Restart();
            new SelectionSortAlgorithm<int>().Sort(selectionSortCollection);
            sw.Stop();
            
            Console.WriteLine("SelectionSort: " + sw.Elapsed);
            
            #endregion

            #region [Validate result]

            if (!Utils.AreSequencesEqual(quickSortCollection, mergeSortCollection) ||
                !Utils.AreSequencesEqual(mergeSortCollection, selectionSortCollection) ||
                !Utils.AreSequencesEqual(selectionSortCollection, insertionSortCollection))
            {
                throw new ArgumentException("Sorting does not work correctly.");
            }
            
            #endregion
        }
        
        private static void TestWithDoubles(bool areSorted = false, bool isReversed = true)
        {
            var randomDoubles = Utils.GetArrayWithRandomDoubles(Capacity);
            sw.Reset();
            
            if (areSorted)
            {
                Array.Sort(randomDoubles);
            }
            
            if (isReversed)
            {
                Array.Reverse(randomDoubles);
            }
            
            #region [Quicksort]
            
            var quickSortCollection = randomDoubles.ToList();
            
            sw.Start();
            new QuickSortAlgorithm<double>().Sort(quickSortCollection);
            sw.Stop();
            
            Console.WriteLine("QuickSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Mergesort]
            
            var mergeSortCollection = randomDoubles.ToList();
            
            sw.Restart();
            new MergeSortAlgorithm<double>().Sort(mergeSortCollection);
            sw.Stop();
            
            Console.WriteLine("MergeSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Insertion sort]
            
            var insertionSortCollection = randomDoubles.ToList();
            
            sw.Restart();
            new InsertionSortAlgorithm<double>().Sort(insertionSortCollection);
            sw.Stop();
            
            Console.WriteLine("InsertionSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Selection sort]
            
            var selectionSortCollection = randomDoubles.ToList();
            
            sw.Restart();
            new SelectionSortAlgorithm<double>().Sort(selectionSortCollection);
            sw.Stop();
            
            Console.WriteLine("SelectionSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Validate result]
            
            if (!Utils.AreSequencesEqual(quickSortCollection, mergeSortCollection) ||
                !Utils.AreSequencesEqual(mergeSortCollection, selectionSortCollection) ||
                !Utils.AreSequencesEqual(selectionSortCollection, insertionSortCollection))
            {
                throw new ArgumentException("Sorting does not work correctly.");
            }
        
            #endregion
        }
        
        private static void TestWithStrings(bool areSorted = false, bool isReversed = true)
        {
            var randomStrings = Utils.GetArrayWithRandomStrings(Capacity);
            sw.Reset();
            
            if (areSorted)
            {
                Array.Sort(randomStrings);
            }
            
            if (isReversed)
            {
                Array.Reverse(randomStrings);
            }
            
            #region [Quicksort]
            
            var quickSortCollection = randomStrings.ToList();
            
            sw.Start();
            new QuickSortAlgorithm<string>().Sort(quickSortCollection);
            sw.Stop();
            
            Console.WriteLine("QuickSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Mergesort]
            
            var mergeSortCollection = randomStrings.ToList();
            
            sw.Restart();
            new MergeSortAlgorithm<string>().Sort(mergeSortCollection);
            sw.Stop();
            
            Console.WriteLine("MergeSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Insertion sort]
            
            var insertionSortCollection = randomStrings.ToList();
            
            sw.Restart();
            new InsertionSortAlgorithm<string>().Sort(insertionSortCollection);
            sw.Stop();
            
            Console.WriteLine("InsertionSort: " + sw.Elapsed);
            
            #endregion
            
            #region [Selection sort]
            
            var selectionSortCollection = randomStrings.ToList();
            
            sw.Restart();
            new SelectionSortAlgorithm<string>().Sort(selectionSortCollection);
            sw.Stop();
            
            Console.WriteLine("SelectionSort: " + sw.Elapsed);
            
            #endregion

            #region [Validate result]
                
            if (!Utils.AreSequencesEqual(quickSortCollection, mergeSortCollection) ||
                !Utils.AreSequencesEqual(mergeSortCollection, selectionSortCollection) ||
                !Utils.AreSequencesEqual(selectionSortCollection, insertionSortCollection))
            {
                throw new ArgumentException("Sorting does not work correctly.");
            }
    
            #endregion
        }
    }
}