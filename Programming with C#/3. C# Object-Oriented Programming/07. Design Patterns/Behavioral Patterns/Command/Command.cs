namespace Command
{
    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    internal abstract class Command
    {
        public abstract void Execute();

        public abstract void UnExecute();
    }
}
