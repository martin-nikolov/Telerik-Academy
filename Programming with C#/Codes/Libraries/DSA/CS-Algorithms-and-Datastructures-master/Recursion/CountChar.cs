using System;

namespace CodingPractice.Recursion
{
    public static class CountChar
    {
        public static void run()
        {
            string input = "aabc";
            Console.WriteLine(count(input, 'a', 0));
        }

        private static int count(string intput, char needle, int index)
        {
            if (index >= intput.Length)
            {
                return 0;
            }

            int contribution = intput[index] == needle ? 1 : 0;
            return contribution + count(intput, needle, index + 1);
        }
    }
}