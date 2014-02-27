using System;

namespace CodingPractice.Recursion
{
    public static class ChangeXY
    {
        public static void run()
        {
            Console.WriteLine(changeXY("cxdex", 0, ""));
        }

        private static string changeXY(string ip, int i, string op)
        {
            //Base case.
            if (i >= ip.Length)
                return op;

            //Actual replacement logic.
            op = ip[i] == 'x' ? op + 'y' : op + ip[i];

            //Recursive calls.
            return changeXY(ip, i + 1, op);
        }
    }
}