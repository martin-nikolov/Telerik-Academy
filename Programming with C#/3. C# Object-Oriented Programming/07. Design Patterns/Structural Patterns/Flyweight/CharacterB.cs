namespace Flyweight
{
    using System;

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterB : Character
    {
        public CharacterB()
        {
            this.Symbol = 'B';
            this.Height = 100;
            this.Width = 140;
            this.Ascent = 72;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine("{0} (point size {1})", this.Symbol, this.PointSize);
        }
    }
}
