namespace Refactoring
{
    using System;

    public static class LoopRefactoring
    {
        public static void Main()
        {
            int[] collection = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int valueForSearching = 4;

            bool hasValue = collection.Contains(valueForSearching);

            Console.WriteLine("Collection {0}contains value '{1}'...\n", hasValue ? "" : "does not ", valueForSearching);
        }

        /// <summary>
        /// Returns true if this array contains specified value, otherwise returns false.
        /// </summary>
        /// <typeparam name="T">The type of elements</typeparam>
        /// <param name="array">The array contains elements</param>
        /// <param name="valueForSearching">The value for searching in array</param>
        /// <param name="indexStep">The array index amendment</param>
        /// <returns>True if this array contains specified value, otherwise returns false.</returns>
        public static bool Contains<T>(this T[] array, T valueForSearching, int indexStep = 1) where T : IComparable<T>
        {
            bool isFound = false;

            for (int i = 0; i < array.Length; i += indexStep)
            {
                if (array[i].CompareTo(valueForSearching) == 0)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }
    }
}