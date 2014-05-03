namespace Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Games.IOEngines;
    using Games.Interfaces;

    public class MinesGame
    {
        private const int Rows = 5;
        private const int Cols = 10;
        private const int RankListCapacity = 6;
        private const int MaxPoints = 35;

        private const char InitialPlaygroundCellSign = '?';
        private const char EmptyPlaygroundCellSign = '-';
        private const char BombCellSign = '*';

        private readonly List<Winner> rankList = new List<Winner>(RankListCapacity);

        private readonly IWriter consoleWriter = new ConsoleWriter();
        private readonly IReader consoleReader = new ConsoleReader();

        private char[,] playground;
        private char[,] bombs;

        private bool isDead, isWinner;
        private int pointsCount = 0;

        public MinesGame()
        {
            this.playground = this.CreateNewPlayground(Rows, Cols, InitialPlaygroundCellSign);
            this.bombs = this.CreatePlaygroundWithBombs();
        }

        public void Start()
        {
            this.consoleWriter.ShowCommands();
            this.consoleWriter.ShowPlayground(this.playground);

            string inputCommand = string.Empty;

            do
            {
                int row = 0, col = 0;

                this.consoleWriter.ShowMessage("Enter row and col (or command): ");
                inputCommand = this.consoleReader.ReadCommand();

                if (this.TryParseCoords(ref row, ref col, inputCommand))
                {
                    inputCommand = "turn";
                }

                switch (inputCommand)
                {
                    case "turn":
                        {
                            this.ExecuteTurnCommand(row, col);
                            break;
                        }

                    case "top":
                        {
                            this.consoleWriter.ShowRankList(this.rankList);
                            break;
                        }

                    case "restart":
                        {
                            this.ExecuteRestartCommand();
                            break;
                        }

                    case "exit":
                        {
                            this.consoleWriter.ShowMessage("\nYou have left the game!");
                            break;
                        }

                    default:
                        {
                            this.consoleWriter.ShowMessage("\n - Error! Invalid input command!\n\n");
                            break;
                        }
                }

                if (this.IsGameEnd(this.pointsCount))
                {
                    this.pointsCount = 0;
                    this.isWinner = false;
                    this.isDead = false;
                }
            }
            while (inputCommand != "exit");

            this.consoleReader.ReadCommand();
        }
  
        private void ExecuteTurnCommand(int row, int col)
        {
            if (this.bombs[row, col] != BombCellSign)
            {
                if (this.bombs[row, col] == EmptyPlaygroundCellSign)
                {
                    this.PlaceBombsCountNearToCell(this.playground, this.bombs, row, col);
                    this.pointsCount++;
                }

                if (MaxPoints == this.pointsCount)
                {
                    this.isWinner = true;
                }
                else
                {
                    this.consoleWriter.ShowPlayground(this.playground);
                }
            }
            else
            {
                this.isDead = true;
            }
        }

        private void ExecuteRestartCommand()
        {
            this.playground = this.CreateNewPlayground(Rows, Cols, InitialPlaygroundCellSign);
            this.bombs = this.CreatePlaygroundWithBombs();
            this.consoleWriter.ShowPlayground(this.playground);
        }

        private char[,] CreateNewPlayground(int rows, int cols, char cellSign)
        {
            char[,] playground = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playground[i, j] = cellSign;
                }
            }

            return playground;
        }

        private char[,] CreatePlaygroundWithBombs()
        {
            char[,] playground = this.CreateNewPlayground(Rows, Cols, EmptyPlaygroundCellSign);
            IList<int> randomIntegers = new List<int>();

            while (randomIntegers.Count < 15)
            {
                Random randomGenerator = new Random();
                int randomInteger = randomGenerator.Next(50);

                if (!randomIntegers.Contains(randomInteger))
                {
                    randomIntegers.Add(randomInteger);
                }
            }

            foreach (int randomNumber in randomIntegers)
            {
                int row = randomNumber / Cols;
                int col = randomNumber % Cols;

                if (col == 0 && randomNumber != 0)
                {
                    row--;
                    col = Cols;
                }
                else
                {
                    col++;
                }

                playground[row, col - 1] = BombCellSign;
            }

            return playground;
        }

        private bool TryParseCoords(ref int row, ref int col, string inputCommand)
        {
            if (inputCommand.Length >= 3)
            {
                if (int.TryParse(inputCommand[0].ToString(), out row) && int.TryParse(inputCommand[2].ToString(), out col))
                {
                    if (row <= this.playground.GetLength(0) && col <= this.playground.GetLength(1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsGameEnd(int pointsCount)
        {
            if (this.isDead)
            {
                this.consoleWriter.ShowMessage("\nGAME OVER!\n");
                this.consoleWriter.ShowMessage(string.Format("You win {0} points!\n\n", pointsCount));
                this.GetWinnerInformation(pointsCount);
                this.ExecuteRestartCommand();

                return true;
            }

            if (this.isWinner)
            {
                this.consoleWriter.ShowMessage("\nCongratulations!\n");
                this.consoleWriter.ShowMessage(string.Format("You have opened all the {0} cells!\n", pointsCount));
                this.GetWinnerInformation(pointsCount);
                this.ExecuteRestartCommand();

                return true;
            }

            return false;
        }

        private int GetBombsCount(char[,] playground, int row, int col)
        {
            int bombsCount = 0;
            int rows = playground.GetLength(0);
            int cols = playground.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playground[row - 1, col] == BombCellSign)
                {
                    bombsCount++;
                }

                if (col - 1 >= 0)
                {
                    if (playground[row - 1, col - 1] == BombCellSign)
                    {
                        bombsCount++;
                    }
                }

                if (col + 1 < cols)
                {
                    if (playground[row - 1, col + 1] == BombCellSign)
                    {
                        bombsCount++;
                    }
                }
            }

            if (row + 1 < rows)
            {
                if (playground[row + 1, col] == BombCellSign)
                {
                    bombsCount++;
                }

                if (col - 1 >= 0)
                {
                    if (playground[row + 1, col - 1] == BombCellSign)
                    {
                        bombsCount++;
                    }
                }

                if (col + 1 < cols)
                {
                    if (playground[row + 1, col + 1] == BombCellSign)
                    {
                        bombsCount++;
                    }
                }
            }

            if (col - 1 >= 0)
            {
                if (playground[row, col - 1] == BombCellSign)
                {
                    bombsCount++;
                }
            }

            if (col + 1 < cols)
            {
                if (playground[row, col + 1] == BombCellSign)
                {
                    bombsCount++;
                }
            }

            return bombsCount;
        }

        private void PlaceBombsCountNearToCell(char[,] playground, char[,] bombs, int row, int col)
        {
            int bombsCount = this.GetBombsCount(bombs, row, col);
            char bombsCountToChar = char.Parse(bombsCount.ToString());

            bombs[row, col] = bombsCountToChar;
            playground[row, col] = bombsCountToChar;
        }
  
        private void GetWinnerInformation(int pointsCount)
        {
            this.consoleWriter.ShowMessage("Enter your nickname: ");
            string nickname = this.consoleReader.ReadCommand();

            Winner winner = new Winner(nickname, pointsCount);
            this.AddWinnerToRankList(winner);
        }
  
        private void AddWinnerToRankList(Winner winner)
        {
            if (this.rankList.Count < RankListCapacity)
            {
                this.rankList.Add(winner);
            }
            else
            {
                for (int i = 0; i < this.rankList.Count; i++)
                {
                    if (this.rankList[i].Points < winner.Points)
                    {
                        this.rankList.Insert(i, winner);
                        this.rankList.RemoveAt(this.rankList.Count - 1);
                        break;
                    }
                }
            }

            this.rankList.Sort((Winner w1, Winner w2) => w2.Name.CompareTo(w1.Name));
            this.rankList.Sort((Winner w1, Winner w2) => w2.Points.CompareTo(w1.Points));
        }
    }
}