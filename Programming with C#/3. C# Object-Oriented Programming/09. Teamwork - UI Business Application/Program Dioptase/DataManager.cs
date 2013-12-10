namespace ProgramDioptase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using ProgramDioptase.Interfaces.DatabaseManager;
    using ProgramDioptase.Interfaces.ItemDescription;
    using ProgramDioptase.Interfaces.ItemTypes;

    public sealed class DataManager : IFileManager
    {
        private static Uri ResourcePath = new Uri(@"Resources", UriKind.RelativeOrAbsolute);
        private static Uri ClientPath = new Uri(@"../../Clients", UriKind.RelativeOrAbsolute);
        private static Uri LibraryPath = new Uri(@"Library", UriKind.RelativeOrAbsolute);
        private static Uri MoviePath = new Uri(string.Format(@"../../{0}\Movies", LibraryPath), UriKind.RelativeOrAbsolute);
        private static Uri GamePath = new Uri(string.Format(@"../../{0}\Games", LibraryPath), UriKind.RelativeOrAbsolute);
        private static Uri MusicPath = new Uri(string.Format(@"../../{0}\Music", LibraryPath), UriKind.RelativeOrAbsolute);

        public DataManager()
        {
        }

        public string GetStatisticData(Uri baseDirectory, string fileName = "statistics")
        {
            string result = string.Empty;

            if (File.Exists(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
            {
                result = new StreamReader(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)).ReadToEnd();

                if (string.IsNullOrEmpty(result))
                    result = "0";
            }
            else
            {
                using (File.Create(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
                {
                    // ...                    
                }

                result = "0";
            }

            return result;
        }

        public decimal SetStatisticInfo(Uri baseDirectory, decimal count, string fileName = "statistics")
        {
            string result = string.Empty;

            if (!File.Exists(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
            {
                using (File.Create(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
                {
                    // ...                    
                }
            }
            else
            {
                using (var reader = new StreamReader(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
                {
                    result = reader.ReadToEnd();                
                }
            }

            decimal intResult = 0;

            if (string.IsNullOrEmpty(result))
            {
                intResult = count;
            }
            else
            {
                intResult = decimal.Parse(result) + count;
            }

            using (var writer = new StreamWriter(string.Format(@"{0}\{1}.txt", baseDirectory, fileName)))
            {
                writer.WriteLine(intResult);
            }

            return intResult;
        }

        public IList<string> GetUserOrdersInfo(string clientName)
        {
            List<string> orders = new List<string>();

            Uri baseDirectory = this.GetBaseDirectory("Client");
            
            if (File.Exists(string.Format(@"{0}\{1}\orders.txt", baseDirectory, clientName)))
            {
                using (StreamReader countReader = new StreamReader(
                    string.Format(@"{0}\{1}\orders.txt", baseDirectory, clientName)))
                {
                    while (!countReader.EndOfStream)
                    {
                        var currentOrder = countReader.ReadLine();

                        if (!string.IsNullOrEmpty(currentOrder))
                        {
                            orders.Add(currentOrder);
                        }
                    }
                }
            }

            return orders;
        }

        public void MakeClientOrder(string clientName, IList<IDescription> catalogItems)
        {
            Uri baseDirectory = this.GetBaseDirectory("Client");

            if (!File.Exists(string.Format(@"{0}\{1}\orders.txt", baseDirectory, clientName)))
            {
                using (File.Create(string.Format(@"{0}\{1}\orders.txt", baseDirectory, clientName)))
                {
                    // ...                    
                }
            }
            
            using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\{1}\orders.txt", baseDirectory, clientName), true))
            {
                foreach (var item in catalogItems)
                {
                    StringBuilder currentOrderInfo = new StringBuilder();
                    currentOrderInfo.AppendFormat("{0};{1};{2};", item.GetType().Name, item.Name, item.ReleaseYear);

                    if (item is ISaleable)
                    {
                        currentOrderInfo.AppendFormat((item as ISaleable).Price.ToString());
                    }
                    else if (item is IRentable)
                    {
                        var itemRentableInfo = item as IRentable;

                        currentOrderInfo.AppendFormat("{0};{1};{2}",
                            itemRentableInfo.RentalDate.ToShortDateString(),
                            itemRentableInfo.ReturnDate.ToShortDateString(),
                            itemRentableInfo.TotalPrice);
                    }

                    writer.WriteLine(currentOrderInfo);
                }
            }
        }

        public Uri GetBaseDirectory(string type)
        {
            Uri baseDirectory = default(Uri);

            switch (type)
            {
                case "Movie": baseDirectory = DataManager.MoviePath; break;
                case "Game": baseDirectory = DataManager.GamePath; break;
                case "Music": baseDirectory = DataManager.MusicPath; break;
                case "Client": baseDirectory = DataManager.ClientPath; break;
                case "Resource": baseDirectory = DataManager.ResourcePath; break;
                case "Library": baseDirectory = new Uri(@"../../Library", UriKind.RelativeOrAbsolute); break;
            }

            if (baseDirectory == null)
            {
                throw new ArgumentException();
            }

            return baseDirectory;
        }

        public IList<T> GetItems<T>(Uri baseDirectory)
            where T : IDataInitializable, new()
        {
            var allItems = new List<T>();

            if (Directory.Exists(baseDirectory.ToString()) && File.Exists(string.Format(@"{0}\items.txt", baseDirectory)))
            {
                // Reading all items names
                var itemNames = this.ReadItemsNames(baseDirectory);

                // Reading item information by item name
                this.InitializeObjectData<T>(itemNames, baseDirectory, allItems);
            }

            return allItems;
        }

        public IList<string> ReadItemsNames(Uri baseDirectory)
        {
            var itemNames = new List<string>();

            using (StreamReader itemNameReader = new StreamReader(string.Format(@"{0}\items.txt", baseDirectory)))
            {
                while (!itemNameReader.EndOfStream)
                {
                    itemNames.Add(itemNameReader.ReadLine());
                }
            }

            return itemNames;
        }

        public void InitializeObjectData<T>(IList<string> itemNames, Uri baseDirectory, IList<T> allItems)
            where T : IDataInitializable, new()
        {
            // Reading item information by item name
            foreach (var itemName in itemNames)
            {
                string itemDirectory = string.Format(@"{0}\{1}", baseDirectory, itemName);

                if (Directory.Exists(itemDirectory) && File.Exists(itemDirectory + @"\info.txt"))
                {
                    using (StreamReader itemInfo = new StreamReader(string.Format(@"{0}\{1}\info.txt", baseDirectory, itemName)))
                    {
                        string[] components = itemInfo.ReadToEnd().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        var currentItem = new T();
                        currentItem.InitializeData(components);

                        allItems.Add(currentItem);
                    }
                }
            }
        }
    }
}