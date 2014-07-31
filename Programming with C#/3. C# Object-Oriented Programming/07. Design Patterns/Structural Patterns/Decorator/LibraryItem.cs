namespace Decorator
{
    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    internal abstract class LibraryItem
    {
        public int CopiesCount { get; set; }

        public abstract void Display();
    }
}
