using System;

namespace TickMarks
{
    class TickMarks
    {
        public const int NumberOfTicks = 10;

        static void Main()
        {
            Console.Write("Enter minimal value: ");
            int minValue = int.Parse(Console.ReadLine());
            Console.Write("Enter maximal value: ");
            int maxValue = int.Parse(Console.ReadLine());

            int length = maxValue - minValue;
            if (length == 0 || length == 1)
            {
                minValue--;
                maxValue++;
            }

            int a = maxValue - minValue;
            int aexp = (int)Math.Log10(a);
            double af = a / Math.Pow(10, aexp);

            int nf;
            if (af <= 1) nf = 1;
            else if (af <= 2) nf = 2;
            else if (af <= 5) nf = 5;
            else nf = 10;

            int range = nf * (int)Math.Pow(10, aexp);


            int b = range / (NumberOfTicks - 1);
            int bexp = (int)Math.Log10(b);
            double bf = b / Math.Pow(10, bexp);

            if (bf <= 1.5) nf = 1;
            else if (bf <= 3) nf = 2;
            else if (bf <= 7) nf = 5;
            else nf = 10;

            int step = nf * (int)Math.Pow(10, bexp);
            double minScale = Math.Floor((double)minValue / step) * step;
            double maxScale = Math.Ceiling((double)maxValue / step) * step;

            Console.WriteLine("Scale: form {0} to {2}, step {1}", minScale, step, maxScale);
        }
    }
}