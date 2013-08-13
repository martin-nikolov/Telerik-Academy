using System;
using System.Linq;

class TicTacToe
{
    public static int playerXWins = 0, playerOWins = 0, draws = 0;

    static char[,] field = new char[3, 3];
    static int currentPlayer = 1, currentWinner = 0; // 1 for 'X', 2 for 'O'

    public TicTacToe() { }

    public void InitializeField()
    {
        int countX = 0, countO = 0;

        for (int row = 0; row < 3; row++)
        {
            string line = Console.ReadLine();

            for (int col = 0; col < 3; col++)
            {
                field[row, col] = line[col];

                if (line[col] == 'X') countX++;
                else if (line[col] == 'O') countO++;
            }
        }

        if (countX > countO) currentPlayer = 2; // 'O' starts
        else currentPlayer = 1; // 'X' starts
    }

    public void Solve(int x, int y)
    {
        if (HorizontalWin() || VerticalWin() || DiagonalWin())
        {
            if (currentWinner == 1) playerXWins++;
            else playerOWins++;

            currentWinner = 0;

            return;
        }
        else if (IsFull())
        {
            draws++;
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (field[row, col] == '-')
                {
                    if (currentPlayer == 1) field[row, col] = 'X';
                    else if (currentPlayer == 2) field[row, col] = 'O';

                    currentPlayer = 3 - currentPlayer; // Next player

                    Solve(row, col);

                    field[row, col] = '-';

                    currentPlayer = 3 - currentPlayer; // Previous player
                }
            }
        }
    }

    static bool HorizontalWin()
    {
        for (int row = 0; row < 3; row++)
        {
            if (field[row, 0].Equals(field[row, 1]) && field[row, 1].Equals(field[row, 2]) && field[row, 0] != '-')
            {
                if (field[row, 0] == 'X') currentWinner = 1;
                else currentWinner = 2;
                return true;
            }
        }

        return false;
    }

    static bool VerticalWin()
    {
        for (int col = 0; col < 3; col++)
        {
            if (field[0, col].Equals(field[1, col]) && field[1, col].Equals(field[2, col]) && field[0, col] != '-')
            {
                if (field[0, col] == 'X') currentWinner = 1;
                else currentWinner = 2;
                return true;
            }
        }

        return false;
    }

    static bool DiagonalWin()
    {
        // left-to-right
        if (field[0, 0].Equals(field[1, 1]) && field[1, 1].Equals(field[2, 2]) && field[0, 0] != '-')
        {
            if (field[0, 0] == 'X') currentWinner = 1;
            else currentWinner = 2;
            return true;
        }

        // right-to-left
        if (field[0, 2].Equals(field[1, 1]) && field[1, 1].Equals(field[2, 0]) && field[0, 2] != '-')
        {
            if (field[0, 2] == 'X') currentWinner = 1;
            else currentWinner = 2;
            return true;
        }

        return false;
    }

    static bool IsFull()
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (field[row, col] == '-') return false;

        return true;
    }
}

class Program
{
    static void Main()
    {
        TicTacToe field = new TicTacToe();
        field.InitializeField();

        field.Solve(0, 0);

        Console.WriteLine(TicTacToe.playerXWins);
        Console.WriteLine(TicTacToe.draws);
        Console.WriteLine(TicTacToe.playerOWins);
    }
}
