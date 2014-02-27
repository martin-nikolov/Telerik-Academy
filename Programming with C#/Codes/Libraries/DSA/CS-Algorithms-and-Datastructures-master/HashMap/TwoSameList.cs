using System;
using System.Collections.Generic;

namespace CodingPractice
{
    public static class TwoSameList
    {
        private static int[] a;
        private static int[] b;
        private static Dictionary<int, int> dict;

        public static void run()
        {
            a = new[] {1, 2, 3, 4, 5, 6};
            b = new[] {1, 2, 3, 4, 5, 6};

            Console.WriteLine(isSame());
        }

        private static bool isSame()
        {
            bool isSame = true;
            populateDictionary();

            foreach (int i in b)
            {
                if (dict.ContainsKey(i))
                {
                    if (dict[i] < 0) //we have less elements in the original array
                    {
                        isSame = false;
                        break;
                    }
                    dict[i] = dict[i] - 1; //key found so decrease the count
                }
                else
                {
                    isSame = false; //key not found
                }
            }

            foreach (int i in a)
            {
                if (dict[i] > 0) //this means we have more element in original array
                    isSame = false;
            }

            return isSame;
        }

        private static void populateDictionary()
        {
            dict = new Dictionary<int, int>();

            foreach (int i in a)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] = dict[i] + 1;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
        }
    }
}