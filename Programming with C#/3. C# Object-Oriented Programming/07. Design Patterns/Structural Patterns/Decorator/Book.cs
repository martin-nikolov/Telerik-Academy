namespace Decorator
{
    using System;

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class Book : LibraryItem
    {
        private readonly string author;
        private readonly string title;

        public Book(string author, string title, int copiesCount)
        {
            this.author = author;
            this.title = title;
            this.CopiesCount = copiesCount;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", this.author);
            Console.WriteLine(" Title: {0}", this.title);
            Console.WriteLine(" # Copies: {0}", this.CopiesCount);
        }
    }
}
