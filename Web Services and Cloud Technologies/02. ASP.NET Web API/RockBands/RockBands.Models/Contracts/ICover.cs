namespace RockBands.Models.Contracts
{
    using System;
    using System.Linq;

    public interface ICover
    {
        string Name { get; set; }

        string ImageUrl { get; set; }

        string Src { get; set; }

        int Rating { get; set; }
    }
}