using System;
using System.Linq;

namespace ProgramDioptase.Interfaces.DatabaseManager
{
    public interface IStatisticManager
    {
        decimal MovieOrdersCount { get; }

        decimal GameOrdersCount { get; }

        decimal MusicOrdersCount { get; }
    }
}