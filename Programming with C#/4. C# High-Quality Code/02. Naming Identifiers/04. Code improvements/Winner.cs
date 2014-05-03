namespace Games
{
    using System;
    using System.Linq;

    public class Winner
    {
        public Winner(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}