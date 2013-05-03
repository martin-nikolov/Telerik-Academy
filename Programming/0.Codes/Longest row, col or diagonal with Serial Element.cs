using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[,] matrix =
        {
            { "ha", "ha", "ha", "xx" },
            { "ha", "hi", "fo", "xx" },
            { "ha", "fo", "hi", "xx" },
            { "fo", "fo", "fo", "hi" }
        };

        int totalRows = (int)matrix.GetLongLength(0);
        int totalCols = (int)matrix.GetLongLength(1);

        //Directions
        //1st - RIGHT ][ 2nd - LEFT-TO-RIGHT DIAGONAL ][ 3rd - DOWN ][ 4th - RIGHT-TO-LEFT DIAGONAL
        int[] dirRow = { 0, 1, 1, -1 };
        int[] dirCol = { 1, 1, 0, 1 };

        List<string>[] bestElem = new List<string>[totalRows * totalCols * 2];
        int currentIndex = 0;

        for (int i = 0; i < bestElem.Length; i++)
        {
            bestElem[i] = new List<string>();
        }

        int bestLength = 0;

        //Crawling the matrix
        for (int row = 0; row < totalRows; row++)
        {
            for (int col = 0; col < totalCols; col++)
            {
                //Crawling every direction
                for (int direction = 0; direction < 4; direction++)
                {
                    bestElem[currentIndex].Add(matrix[row, col]);

                    int currentRow = row;
                    int currentCol = col;
                    int currentLength = 1;

                    while (true)
                    {
                        currentRow = currentRow + dirRow[direction];
                        currentCol = currentCol + dirCol[direction];

                        //Out of range => break
                        if (currentRow < 0 || currentRow >= totalRows ||
                            currentCol < 0 || currentCol >= totalCols ||
                            matrix[currentRow, currentCol] != matrix[row, col])
                        {
                            //Collect the best length
                            if (currentLength > bestLength)
                            {
                                bestLength = currentLength;
                            }

                            if (bestElem[currentIndex].Count < bestLength)
                            {
                                //Clear current list if it count is less than bestLength
                                //and write in for -th (serial) time
                                bestElem[currentIndex].Clear();
                            }
                            else
                            {
                                //Write future statements in new list
                                currentIndex++;
                            }

                            break;
                        }

                        currentLength++;
                        bestElem[currentIndex].Add(matrix[currentRow, currentCol]);
                    }
                }
            }
        }

        //Printing longest row with serial similar elements
        PrintBestRows(bestElem, bestLength);
    }

    private static void PrintBestRows(List<string>[] bestElem, int bestLength)
    {
        for (int i = 0; i < bestElem.Length; i++)
        {
            if (bestElem[i].Count == bestLength)
            {
                foreach (var item in bestElem[i])
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }
        }
        
    }
}