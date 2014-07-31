namespace Decorator
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            // Create book
            var book = new Book("Microsoft", "CLR via C# 3", 10);
            book.Display();

            // Create video
            var video = new Video("Stanley Kubrick", "A Clockwork Orange", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            var borrowableVideo = new Borrowable(video);
            borrowableVideo.BorrowItem("Nikolay Kostov");
            borrowableVideo.BorrowItem("George Georgiev");

            borrowableVideo.Display();
        }
    }
}
