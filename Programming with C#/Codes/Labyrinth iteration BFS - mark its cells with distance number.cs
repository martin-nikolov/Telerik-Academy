using System;
using System.Collections.Generic;
using System.Linq;

class LabyrinthIterationBFS
{
    static string[,] labyrinth = 
    {
        { "0", "0", "0", "x", "0", "x" },
        { "0", "x", "0", "x", "0", "x" },
        { "0", "*", "x", "0", "x", "0" },
        { "0", "x", "0", "0", "0", "0" },
        { "0", "0", "0", "x", "x", "0" },
        { "0", "0", "0", "x", "0", "x" }
    };

    static Cell initialCell = null;

    static void Main()
    {
        Queue<Cell> visitedCells = new Queue<Cell>();

        FindStartingCell();
        PrintLabyrinth();

        VisitCell(visitedCells, initialCell.Row, initialCell.Col, 0);

        // Perform Breath-First-Search (BFS)
        while (visitedCells.Count > 0)
        {
            Cell currentCell = visitedCells.Dequeue();
            int row = currentCell.Row;
            int col = currentCell.Col;
            int distance = currentCell.Distance;

            VisitCell(visitedCells, row, col + 1, distance + 1);
            VisitCell(visitedCells, row, col - 1, distance + 1);
            VisitCell(visitedCells, row + 1, col, distance + 1);
            VisitCell(visitedCells, row - 1, col, distance + 1);
        }

        MarkInaccessibleCells();
        PrintLabyrinth();
    }

    static void FindStartingCell()
    {
        for (int i = 0; i < labyrinth.GetLongLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLongLength(1); j++)
            {
                if (labyrinth[i, j] == "*")
                {
                    initialCell = new Cell(i, j, 0);
                    return;
                }
            }
        }

        throw new Exception("Start cell is missing -> no path...\n");
    }

    static void VisitCell(Queue<Cell> visitedCells, int row, int col, int distance)
    {
        if (row < 0 || row >= labyrinth.GetLongLength(0) ||
            col < 0 || col >= labyrinth.GetLongLength(1))
            return;

        if (labyrinth[row, col] == "0" || distance == 0)
        {
            // The cell is free --> visit it
            if (distance != 0) labyrinth[row, col] = distance.ToString();
            visitedCells.Enqueue(new Cell(row, col, distance));
        }
    }

    static void MarkInaccessibleCells()
    {
        for (int i = 0; i < labyrinth.GetLongLength(0); i++)
            for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                if (labyrinth[i, j] == "0") labyrinth[i, j] = "u";
    }

    static void PrintLabyrinth()
    {
        for (int i = 0; i < labyrinth.GetLongLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                Console.Write("{0,4}", labyrinth[i, j]);
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public class Cell
    {
        public Cell(int row, int col, int distance)
        {
            this.Row = row;
            this.Col = col;
            this.Distance = distance;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Distance { get; set; }
    }
}