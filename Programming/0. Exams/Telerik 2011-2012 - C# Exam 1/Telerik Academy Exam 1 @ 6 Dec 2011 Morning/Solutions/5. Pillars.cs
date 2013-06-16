using System;
using System.Text;

class Pillars
{
    static int[] number = new int[8];
    static StringBuilder leftMostColumn = new StringBuilder();

    static void Main()
    {
        for (int i = 0; i < number.Length; i++)
            number[i] = int.Parse(Console.ReadLine());

        for (int col = 7; col >= 0; col--)
        {
            int pillarLeftCount = 0;
            for (int col_left = 0; col_left < col; col_left++)
            {
                for (int row_left = 0; row_left < 8; row_left++)
                    if (((number[row_left] >> 7 - col_left) & 1) == 1) pillarLeftCount++;
            }

            int pillarRightCount = 0;
            for (int col_right = col + 1; col_right < 8; col_right++)
            {
                for (int row_right = 0; row_right < 8; row_right++)
                    if (((number[row_right] >> 7 - col_right) & 1) == 1) pillarRightCount++;
            }

            if (pillarLeftCount == pillarRightCount)
                leftMostColumn = new StringBuilder().AppendFormat("{0}\n{1}", 7 - col, pillarRightCount);
        }

        if (leftMostColumn.Length > 0) Console.WriteLine(leftMostColumn);
        else Console.WriteLine("No");
    }
}