using System;
using System.Collections.Generic;
using System.Linq;
using ProgramDioptase.Interfaces.ItemDescription;

namespace ProgramDioptase.ItemTypes
{
    public abstract class CatalogItem : IDataInitializable, IDescription
    {
        public CatalogItem()
        {
        }

        public CatalogItem(string name, List<string> genres, string releseDate)
        {
            this.Name = name;
            this.Genres = genres;
            this.ReleaseYear = releseDate;
        }

        public string Name { get; set; }

        public IList<string> Genres { get; protected set; }

        public string ReleaseYear { get; set; }

        public virtual void InitializeData(string[] components)
        {
            this.Name = components[0];
            this.Genres = components[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            this.ReleaseYear = components[2];
        }
    }
}