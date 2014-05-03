namespace Games.Interfaces
{
    using System.Collections.Generic;

    public interface IWriter
    {
        void ShowCommands();

        void ShowPlayground(char[,] playground);

        void ShowRankList(IList<Winner> winners);

        void ShowMessage(string message);
    }
}