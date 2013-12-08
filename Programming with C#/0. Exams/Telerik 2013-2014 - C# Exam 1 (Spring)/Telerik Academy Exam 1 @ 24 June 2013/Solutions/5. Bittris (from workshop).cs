using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // top to bottom
        uint row0 = 0;
        uint row1 = 0;
        uint row2 = 0;
        uint row3 = 0;
        int score = 0;
        bool gameOver = false;

        string numberAsString = null;

        var piecesCount = int.Parse(Console.ReadLine()) / 4;

        while (piecesCount > 0 && !gameOver)
        {
            piecesCount -= 1;

            numberAsString = Console.ReadLine();

            // end of input?

            if (numberAsString == null)
                break;

            // ex: DDR
            string commands =
                             Console.ReadLine() +
                             Console.ReadLine() +
                             Console.ReadLine();

            // ex: 112
            uint number = uint.Parse(numberAsString);

            // ex: 1110000 -> 111 -> 3
            int numberOfBits = Convert.ToString(number, 2)
                                      .Replace("0", "")
                                      .Length;

            // ignore leading 24 bits
            number &= 255;

            // other option
            // number &= (1 << 8) - 1;

            // loop over the rows until the piece can't go
            // any lower

            for (int thisRowNumber = 0; thisRowNumber <= 3; ++thisRowNumber)
            {
                // should we shift the piece left or right
                if (thisRowNumber < 3)
                {
                    char command = commands[thisRowNumber];

                    if (command == 'L')
                    {
                        // we need to check bit 7
                        if ((number & (1 << 7)) == 0)
                        {
                            number <<= 1;
                        }
                    }
                    else if (command == 'R')
                    {
                        // check bit 0
                        if ((number & 1) == 0)
                        {
                            number >>= 1;
                        }
                    }

                }

                uint nextRow = 0;
                uint thisRow = 0;

                switch (thisRowNumber)
                {
                    case 0: thisRow = row0; nextRow = row1; break;
                    case 1: thisRow = row1; nextRow = row2; break;
                    case 2: thisRow = row2; nextRow = row3; break;
                    case 3: thisRow = row3; break;
                }


                // (nextRow & number) != 0 means the next row is blocked:
                // number:                0011100000
                // nextRow:               0000110010
                // (nextRow & number)     0000100000

                if ((nextRow & number) != 0 || thisRowNumber == 3)
                {

                    // is this row full?
                    if ((thisRow | number) == 255)
                    {
                        score += numberOfBits * 10;

                        // delete this row and move the other rows down

                        switch (thisRowNumber)
                        {
                            case 0:
                                row0 = 0;
                                break;
                            case 1:
                                row1 = row0;
                                break;
                            case 2:
                                row2 = row1;
                                row1 = row0;
                                break;
                            case 3:
                                row3 = row2;
                                row2 = row1;
                                row1 = row0;
                                break;
                        }
                    }
                    else
                    {
                        switch (thisRowNumber)
                        {
                            case 0: row0 |= number; break;
                            case 1: row1 |= number; break;
                            case 2: row2 |= number; break;
                            case 3: row3 |= number; break;
                        }
                        score += numberOfBits;
                    }
                    break;
                }

                // game over?

                if (row0 != 0)
                {
                    gameOver = true;
                    break;
                }

            }

            if (gameOver)
                break;
        }

        Console.WriteLine(score);
    }

}