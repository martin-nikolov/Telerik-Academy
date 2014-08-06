namespace Computers.Models.Components
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class VideoCard
    {
        public VideoCard(bool isMonochrome)
        {
            this.IsMonochrome = isMonochrome;
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string text, IDrawStrategy drawStrategy)
        {
            if (this.IsMonochrome)
            {
                drawStrategy.DrawMonochrome(text);
            }
            else
            {
                drawStrategy.DrawColorful(text);
            }
        }
    }
}