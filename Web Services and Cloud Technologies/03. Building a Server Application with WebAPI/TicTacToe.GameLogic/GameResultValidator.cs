namespace TicTacToe.GameLogic
{
    using TicTacToe.GameLogic.Contracts;
    using TicTacToe.GameLogic.Enum;

    public class GameResultValidator : IGameResultValidator
    {
        private const char EmptyCell = '-';

        public GameResult GetResult(string board)
        {
            // Check rows
            for (int row = 0; row <= 6; row += 3)
            {
                if (board[row] != EmptyCell && board[row] == board[row + 1] && board[row + 1] == board[row + 2])
                {
                    return this.IdentifyPlayer(board[row]);
                }
            }

            // Check columns
            for (int col = 0; col <= 2; col++)
            {
                if (board[col] != EmptyCell && board[col] == board[col + 3] && board[col + 3] == board[col + 6])
                {
                    return this.IdentifyPlayer(board[col]);
                }
            }

            // Check left-to-right diagonal
            if (board[0] != EmptyCell && board[0] == board[4] && board[4] == board[8])
            {
                return this.IdentifyPlayer(board[0]);
            }

            // Check right-to-left diagonal
            if (board[2] != EmptyCell && board[2] == board[4] && board[4] == board[6])
            {
                return this.IdentifyPlayer(board[2]);
            }

            // If there is no '-' => game is draw
            if (!board.Contains("-"))
            {
                return GameResult.Draw;
            }

            return GameResult.NotFinished;
        }

        public GameResult IdentifyPlayer(char playerSymbol)
        {
            if (playerSymbol == 'O')
            {
                return GameResult.WonByO;
            }
            else
            {
                return GameResult.WonByX;
            }
        }
    }
}