namespace Decorator
{
    using System;

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class Video : LibraryItem
    {
        private readonly string director;
        private readonly string title;
        private readonly int playTime;

        public Video(string director, string title, int copiesCount, int playTime)
        {
            this.director = director;
            this.title = title;
            this.CopiesCount = copiesCount;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", this.director);
            Console.WriteLine(" Title: {0}", this.title);
            Console.WriteLine(" # Copies: {0}", this.CopiesCount);
            Console.WriteLine(" Playtime: {0}\n", this.playTime);
        }
    }
}
