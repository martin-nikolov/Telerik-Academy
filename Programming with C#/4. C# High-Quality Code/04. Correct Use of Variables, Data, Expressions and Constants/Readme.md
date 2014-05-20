## Using Variables, Data, Expressions and Constants

1. Refactor the following code to use proper variable naming and simplified expressions:

    ```c#
    using System;

    public class Size
    {
        public double wIdTh, Viso4ina;
        public Size(double w, double h)
        {
            this.wIdTh = w;
            this.Viso4ina = h;
        }
    }

    public static Size GetRotatedSize(
        Size s, double angleOfTheFigureThatWillBeRotaed)
    {
        return new Size(
            Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh +
            Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina,
            Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * s.wIdTh +
            Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * s.Viso4ina);
    }
    ```
* Refactor the following code to apply variable usage and naming best practices:

    ```c#
    public void PrintStatistics(double[] arr, int count)
    {
        double max, tmp;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        PrintMax(max);
        tmp = 0;
        max = 0;
        for (int i = 0; i < count; i++)
        {
            if (arr[i] < max)
            {
                max = arr[i];
            }
        }
        PrintMin(max);

        tmp = 0;
        for (int i = 0; i < count; i++)
        {
            tmp += arr[i];
        }
        PrintAvg(tmp/count);
    }
    ```