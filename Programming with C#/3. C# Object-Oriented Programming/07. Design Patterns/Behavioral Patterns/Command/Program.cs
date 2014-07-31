namespace Command
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var user = new User();

            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            user.Undo(4);

            user.Redo(3);
        }
    }
}
