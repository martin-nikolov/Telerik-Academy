namespace Flyweight
{
    using System;

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    internal class CharacterZ : Character
    {
        public CharacterZ()
        {
            this.Symbol = 'Z';
            this.Height = 100;
            this.Width = 100;
            this.Ascent = 68;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine("{0} (point size {1})", this.Symbol, this.PointSize);
        }
    }
}
