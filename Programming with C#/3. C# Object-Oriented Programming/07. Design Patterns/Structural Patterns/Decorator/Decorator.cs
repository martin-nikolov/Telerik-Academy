namespace Decorator
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : LibraryItem
    {
        protected Decorator(LibraryItem libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        protected LibraryItem LibraryItem { get; set; }

        public override void Display()
        {
            this.LibraryItem.Display();
        }
    }
}
