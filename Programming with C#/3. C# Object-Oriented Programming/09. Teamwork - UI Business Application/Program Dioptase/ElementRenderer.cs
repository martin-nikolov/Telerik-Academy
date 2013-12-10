namespace ProgramDioptase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using ProgramDioptase.ClientDescription;
    using ProgramDioptase.Interfaces.ItemDescription;

    public static class ElementRenderer
    {
        private static readonly Uri resourcePath = App.FileManager.GetBaseDirectory("Resource");

        #region [Operations with Panels - Visualizations & Pushing items in panel]
        
        public static void VisualizeAllElementsToPanel<T>(Panel panel, IList<T> itemsInfo)
            where T : IDescription
        {
            var baseDirectory = App.FileManager.GetBaseDirectory(typeof(T).Name);
            
            panel.Children.Clear();
            
            for (int k = 0; k < 1; k++)
            {
                for (int i = 0; i < itemsInfo.Count; i++)
                {
                    var nestedPanel = new StackPanel();
                    nestedPanel.Margin = new Thickness(10, 0, 0, 20);
                    nestedPanel.Height = 200;
                    nestedPanel.Width = 200;
                    
                    var image = new Image();
                    image.Height = 180;
                    image.MaxHeight = 180;
                    image.Width = 180;
                    image.MaxWidth = 180;
                    image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                    
                    // Loading an image
                    LoadImage(baseDirectory, itemsInfo[i].Name, image);
                    
                    // Add image to Stack Panel
                    nestedPanel.Children.Add(image);
                    
                    // Loading other components as Name, Genre, Year etc.
                    PushItemsInPanel(nestedPanel, itemsInfo[i]);
                    
                    // Set event args
                    var eventInfo = itemsInfo[i];
                    
                    // Set Mouse Click event to Image
                    nestedPanel.MouseLeftButtonDown += (sender, args) =>
                    {
                        var catalogItemInfo = new InformationAboutCatalogItem(eventInfo, baseDirectory);
                        catalogItemInfo.ShowDialog();
                    };
                    
                    panel.Children.Add(nestedPanel);
                }
            }
        }

        public static void VizualizeClientNamesToPanel(ListBox listBox, IList<Client> clients)
        {
            listBox.Items.Clear();

            foreach (var client in clients)
            {
                ListBoxItem clientNameListBoxItem = new ListBoxItem();
                clientNameListBoxItem.Content = client.Name;
                listBox.Items.Add(clientNameListBoxItem);

                // Set event on every name when Mouse Click -> Show information about the client
                clientNameListBoxItem.MouseUp += (sender, args) =>
                {
                    ClientsLibrary.ChangeDataContextOfClientInfoContainer(client);
                };
            }
        }

        private static void PushItemsInPanel(Panel panel, IDescription itemInfo)
        {
            var textBlock = new TextBlock();
            textBlock.TextWrapping = new TextWrapping();
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Text = itemInfo.Name;
            
            textBlock.FontSize = 15;
            panel.Children.Insert(0, textBlock);
        }
        
        #endregion

        #region [Operations with Window]
        
        public static DoubleAnimation WindowAnimation(Window window, int begin = 1, int end = 0, double seconds = 0.3)
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = (window.IsVisible) ? begin : end,
                To = (window.IsVisible) ? end : begin,
                Duration = TimeSpan.FromSeconds(seconds)
            };
        
            return animation;
        }
        
        #endregion

        #region [Operations with images - Loading & Visualization]
        
        public static void VisualizeImageInPanel(Panel panel, string itemName, Uri baseDirectory, int h = 230, int w = 230)
        {
            panel.Children.Clear();
            
            var image = new Image();
            image.Height = h;
            image.MaxHeight = w;
            
            // Loading an image
            LoadImage(baseDirectory, itemName, image);
        
            panel.Children.Add(image);
        }
        
        private static void LoadImage(Uri baseDirectory, string itemDirectory, Image image)
        {
            if (File.Exists(string.Format(@"{0}\{1}\image.jpg", baseDirectory, itemDirectory)))
            {
                Uri uri = new Uri(string.Format(@"{0}\{1}\image.jpg",
                    baseDirectory, itemDirectory), UriKind.RelativeOrAbsolute);
            
                image.Source = BitmapFrame.Create(uri);
            }
            else if (File.Exists(string.Format(@"../../{0}\no-image.png", resourcePath)))
            {
                Uri uri = new Uri(string.Format(@"../../{0}\no-image.png",
                    resourcePath), UriKind.RelativeOrAbsolute);
            
                image.Source = BitmapFrame.Create(uri);
            }
        }
        
        #endregion
        
        #region [Change content of SearchBox & SearchButton container]
            
        public static void VizualizeNewSearchResultByName<T>(Panel allItemsPanel, TextBox searchBox, IList<T> items)
            where T : IDescription
        {
            string searchedText = searchBox.Text.ToLower();
            List<T> result = new List<T>();
            
            if (!string.IsNullOrEmpty(searchedText) && !searchedText.Equals("search by name"))
            {
                result = items.ToList().FindAll(item => item.Name.ToLower().Contains(searchedText));
            }
            else
            {
                result = new List<T>(items);
            }
        
            ElementRenderer.VisualizeAllElementsToPanel(allItemsPanel, result);
        }

        public static void VizualizeNewClientsSearchResult(ListBox listBox, Grid grid, TextBox textBox, IList<Client> list)
        {
            string searchedText = textBox.Text.ToLower();
            List<Client> result = new List<Client>();

            if (!string.IsNullOrEmpty(searchedText) && !searchedText.Equals("search by name"))
            {
                result = list.ToList().FindAll(item => item.Name.ToLower().Contains(searchedText));
            }
            else
            {
                result = new List<Client>(list);
            }

            ElementRenderer.VizualizeClientNamesToPanel(listBox, result);
        }
        
        public static void SearchBoxRemoveContent(TextBox searchBox)
        {
            searchBox.Text = string.Empty;
        }
        
        public static void SearchBoxPutContent(TextBox searchBox)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                searchBox.Text = "Search by name";
            }
        }
    
        #endregion

        #region[Get selected Genres and Vizualize items that contains these genres & Uncheck checkboxed genres]
            
        public static void VizualizeItemsBySelectedGenres<T>(Panel panelToVisualize, Panel selectedGenresPanel, IList<T> items)
            where T : IDescription
        {
            IList<string> selectedGenres = ElementRenderer.GetSelectedGenres(selectedGenresPanel);

            if (selectedGenres.Count > 0)
            {
                IList<T> result = new List<T>();
                
                foreach (var item in items)
                {
                    if (item.Genres.Count >= selectedGenres.Count)
                    {
                        bool valid = true;
                        
                        foreach (var genre in selectedGenres)
                        {
                            if (!item.Genres.Contains(genre))
                            {
                                valid = false;
                                break;
                            }
                        }
                        
                        if (valid)
                        {
                            result.Add(item);
                        }
                    }
                }
            
                ElementRenderer.VisualizeAllElementsToPanel(panelToVisualize, result);
            }
            else
            {
                ElementRenderer.VisualizeAllElementsToPanel(panelToVisualize, items);
            }
        }

        public static void VizualizeItemsBySelectedGenres<T>(
            Panel panelToVisualize, Panel selectedGenresPanel, IList<T> items, string search)
            where T : IDescription
        {
            IList<string> selectedGenres = ElementRenderer.GetSelectedGenres(selectedGenresPanel);

            if (selectedGenres.Count > 0)
            {
                IList<T> result = new List<T>();

                foreach (var item in items)
                {
                    if (item.Genres.Count >= selectedGenres.Count)
                    {
                        bool valid = true;

                        foreach (var genre in selectedGenres)
                        {
                            if (!item.Genres.Contains(genre))
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (valid && item.Name.ToLower().Contains(search.ToLower()))
                        {
                            result.Add(item);
                        }
                    }
                }

                ElementRenderer.VisualizeAllElementsToPanel(panelToVisualize, result);
            }
            else
            {
                ElementRenderer.VisualizeAllElementsToPanel(panelToVisualize, items);
            }
        }

        private static IList<string> GetSelectedGenres(Panel genrePanel)
        {
            IList<string> selectedGenres = new List<string>();
            
            foreach (var control in genrePanel.Children)
            {
                CheckBox checkBox = control as CheckBox;
                
                if (checkBox != null)
                {
                    if (checkBox.IsChecked == true)
                    {
                        selectedGenres.Add(checkBox.Content.ToString());
                    }
                }
            }
            
            selectedGenres.Distinct();
        
            return selectedGenres;
        }
        
        public static void ResetCheckBoxedGenredInExpander(Panel panel)
        {
            foreach (var item in panel.Children)
            {
                var control = item as CheckBox;
                
                if (control != null)
                {
                    control.IsChecked = false;
                }
            }
        }
        
        #endregion
    }
}