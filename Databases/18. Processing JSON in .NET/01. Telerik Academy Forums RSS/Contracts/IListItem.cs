namespace ProcessingJson.Contracts
{
    using System;
    using System.Linq;

    public interface IListItem
    {
        string Title { get; set; }

        string Link { get; set; }

        string Category { get; set; }
    }
}