namespace Computers.Models.Components
{
    using System;
    using System.Linq;
    using Computers.Models.Contracts;

    public class Motherboard : IMotherboard
    {
        private readonly IDrawStrategy drawStrategy;

        public Motherboard(RamMemory ramMemory, VideoCard videoCard)
            : this(ramMemory, videoCard, new VideoCardDrawStrategy())
        {
        }

        public Motherboard(RamMemory ramMemory, VideoCard videoCard, IDrawStrategy drawStrategy)
        {
            this.RamMemory = ramMemory;
            this.VideoCard = videoCard;
            this.drawStrategy = drawStrategy;
        }

        public RamMemory RamMemory { get; set; }

        public VideoCard VideoCard { get; set; }

        public void SaveRamValue(int value)
        {
            this.RamMemory.SaveValue(value);
        }

        public int LoadRamValue()
        {
            return this.RamMemory.LoadValue();
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data, this.drawStrategy);
        }
    }
}