namespace TreesTraversals.Logger
{
    public interface ILogger
    {
        void Log(string format, params object[] parameters);

        string GetAllText();
    }
}