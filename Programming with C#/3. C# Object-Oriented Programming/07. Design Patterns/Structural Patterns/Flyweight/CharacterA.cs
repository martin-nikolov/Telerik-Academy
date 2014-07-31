namespace Flyweight
{
    using System;

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterA : Character
    {
        public CharacterA()
        {
            this.Symbol = 'A';
            this.Height = 100;
            this.Width = 120;
            this.Ascent = 70;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine("{0} (point size {1})", this.Symbol, this.PointSize);
        }
    }
}
