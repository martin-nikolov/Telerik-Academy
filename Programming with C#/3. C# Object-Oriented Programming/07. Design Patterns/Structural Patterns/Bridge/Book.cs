namespace Bridge
{
    using System;

    internal class Book : Manuscript
    {
        public Book(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Title", this.Title));
            Console.WriteLine(Formatter.Format("Author", this.Author));
            Console.WriteLine(Formatter.Format("Text", this.Text));
            Console.WriteLine();
        }
    }
}
