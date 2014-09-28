namespace TicTacToe.ConsoleClient
{
    using System;
    using System.Linq;
    using TicTacToe.Data.Contracts;
    using TicTacToe.Data.UnitOfWork;

    public class TicTacToeConsoleClient
    {
        private static readonly ITicTacToeData ticTacToeData = new TicTacToeData();

        internal static void Main()
        {
            Console.WriteLine(ticTacToeData.Games.All().Count());
        }
    }
}