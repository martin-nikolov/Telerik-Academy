namespace ProcessingXml.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProcessingXml.Models;

    public class Band
    {
        private ICollection<Album> albums;

        public Band()
        {
            this.albums = new List<Album>();
        }

        public string Name { get; set; }

        public ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }
    }
}