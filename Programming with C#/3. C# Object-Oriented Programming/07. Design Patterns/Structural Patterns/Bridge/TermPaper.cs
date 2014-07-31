namespace Bridge
{
    using System;

    internal class TermPaper : Manuscript
    {
        public TermPaper(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Class { get; set; }

        public string Student { get; set; }

        public string Text { get; set; }

        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine(Formatter.Format("Class", this.Class));
            Console.WriteLine(Formatter.Format("Student", this.Student));
            Console.WriteLine(Formatter.Format("Text", this.Text));
            Console.WriteLine(Formatter.Format("References", this.References));
            Console.WriteLine();
        }
    }
}
