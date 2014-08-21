namespace PathFinders
{
    using System;
    using System.Linq;

    public struct Cell
    {
        public Cell(int x, int y, int value)
            : this()
        {
            this.X = x;
            this.Y = y;

            this.Value = value;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Value { get; private set; }
    }
}