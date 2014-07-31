using System;
using System.Collections.Generic;
using System.Linq;

namespace FacadePattern
{
    public class Player : IPlayer
    {
        private ICollection<MediaEntity> playlist;

        private int currentIndex;

        public Player()
        {
            this.playlist = new List<MediaEntity>();
        }

        public void Play()
        {
            if (!playlist.Any())
            {
                Console.WriteLine("There are no items on the playlist. Please load some.");
                return;
            }

            MediaEntity currentPlaylistItem = playlist.ElementAtOrDefault(currentIndex);

            if (currentPlaylistItem == null)
            {
                Console.WriteLine("The item was not found!");
                return;
            }

            Console.WriteLine("Started playing {0}.{1}", currentPlaylistItem.Title, currentPlaylistItem.FileExtention);
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
            currentIndex = 0;
        }

        public void Next()
        {
            currentIndex++;
            if (currentIndex >= playlist.Count)
            {
                currentIndex = 0;
            }
            Console.WriteLine("Switching to next item...");
        }

        public void Previous()
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = playlist.Count - 1;
            }
            Console.WriteLine("Switching to previous item...");
        }

        public void Load(MediaEntity media)
        {
            this.playlist.Add(media);
            Console.WriteLine("Loaded {0}.{1}", media.Title, media.FileExtention);
        }
    }
}