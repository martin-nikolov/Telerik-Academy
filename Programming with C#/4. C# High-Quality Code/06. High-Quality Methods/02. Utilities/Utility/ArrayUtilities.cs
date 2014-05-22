namespace Geometria.Utility
{
    using System;

    public static class ArrayUtilities
    {
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentException("Elements collection cannot be null");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Sequence contains no elements");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (maxElement < elements[i])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
    }
}