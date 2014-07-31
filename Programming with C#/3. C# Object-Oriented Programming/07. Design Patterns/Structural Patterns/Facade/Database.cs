using System.Collections.Generic;

namespace FacadePattern
{
    public class Database
    {
        private ICollection<MediaEntity> availableMedia;

        public Database()
        {
            this.availableMedia = new List<MediaEntity>();
        }

        public void Add(MediaEntity media)
        {
            this.availableMedia.Add(media);
        }

        public IEnumerable<MediaEntity> GetAvailableMedia()
        {
            return this.availableMedia;
        }
    }
}