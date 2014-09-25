namespace TicTacToe.GameLogic.Contracts
{
    using System;
    using System.Linq;
    using TicTacToe.GameLogic.Enum;

    public interface IGameResultValidator
    {
        GameResult GetResult(string board);
    }
}