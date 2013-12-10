namespace ProgramDioptase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProgramDioptase.CatalogItems;
    using ProgramDioptase.ClientDescription;
    using ProgramDioptase.Interfaces.DatabaseManager;

    public class Resources : ICatalogItemManager, IClientManager, IStatisticManager
    {
        private static IList<Movie> movies;
        private static IList<Game> games;
        private static IList<Music> music;
        private static IList<Client> clients;

        private static decimal movieOrdersCount;
        private static decimal gameOrdersCount;
        private static decimal musicOrdersCount;

        private static decimal totalIncome;

        public Resources(IFileManager dataManager)
        {
            this.DataManager = dataManager;
        }

        private IFileManager DataManager { get; set; }

        #region [Statistic Manager]

        public decimal TotalIncome
        {
            get
            {
                totalIncome = decimal.Parse(this.DataManager.GetStatisticData(this.DataManager.GetBaseDirectory("Library"), "total-income"));

                return totalIncome;
            }
            set { totalIncome = value; }
        }

        public decimal MovieOrdersCount
        {
            get
            {
                movieOrdersCount = decimal.Parse(this.DataManager.GetStatisticData(this.DataManager.GetBaseDirectory("Movie")));

                return movieOrdersCount;
            }
            set { movieOrdersCount = value; }
        }

        public decimal GameOrdersCount
        {
            get
            {
                gameOrdersCount = decimal.Parse(this.DataManager.GetStatisticData(this.DataManager.GetBaseDirectory("Game")));

                return gameOrdersCount;
            }
            set { gameOrdersCount = value; }
        }

        public decimal MusicOrdersCount
        {
            get
            {
                musicOrdersCount = decimal.Parse(this.DataManager.GetStatisticData(this.DataManager.GetBaseDirectory("Music")));

                return musicOrdersCount;
            }
            set { musicOrdersCount = value; }
        }
        
        #endregion

        #region [Catalog Manager]
        
        public IList<Movie> Movies
        {
            get
            {
                if (movies == null)
                {
                    movies = this.DataManager.GetItems<Movie>(this.DataManager.GetBaseDirectory("Movie"));
                }
            
                return movies;
            }
        }
        
        public IList<Game> Games
        {
            get
            {
                if (games == null)
                {
                    games = this.DataManager.GetItems<Game>(this.DataManager.GetBaseDirectory("Game"));
                }
            
                return games;
            }
        }
        
        public IList<Music> Music
        {
            get
            {
                if (music == null)
                {
                    music = this.DataManager.GetItems<Music>(this.DataManager.GetBaseDirectory("Music"));
                }
            
                return music;
            }
        }
        
        #endregion

        #region [Client Manager]

        public IList<Client> Clients
        {
            get
            {
                if (clients == null)
                {
                    clients = this.DataManager.GetItems<Client>(this.DataManager.GetBaseDirectory("Client"));
                }
        
                return clients;
            }
        }
        
        #endregion
    }
}