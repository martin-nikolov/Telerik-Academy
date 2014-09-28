namespace TicTacToe.Data.Contracts
{
    using System;
    using TicTacToe.Models;

    public interface ITicTacToeData : IDisposable
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Game> Games { get; }

        IGenericRepository<Score> Scores { get; }

        int SaveChanges();
    }
}