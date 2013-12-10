namespace ProgramDioptase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using ProgramDioptase.CatalogItems;
    using ProgramDioptase.ClientDescription;
    using ProgramDioptase.Interfaces.ItemDescription;

    public partial class ClientsLibrary : Window
    {
        private static Panel clientInfoContainer;

        public ClientsLibrary()
        {
            this.InitializeComponent();

            try
            {
                ElementRenderer.VizualizeClientNamesToPanel(this.ClientsListBox, App.Resources.Clients);
                clientInfoContainer = this.InfoAboutClientGrid;

                this.HideClientDescriptionImages();
                this.ShowBasketItemsToGrid();
            }
            catch (Exception)
            {
                new ApplicationProccessException();
            }
        }

        #region [Client Info Contaioner - operations]

        private void ClientInfoContainer_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.ShowClientDescriptionImages();

            Client selectedClient = this.InfoAboutClientGrid.DataContext as Client;

            if (Basket.PurchasedItems.Count > 0 || Basket.RentedItems.Count > 0)
            {
                this.MakeOrderButton.Visibility = System.Windows.Visibility.Visible;

                this.MakeOrderButton.Click += (sdr, args) =>
                {
                    this.OnMakeOrderButtonClick((this.InfoAboutClientGrid.DataContext as Client).Name, new RoutedEventArgs());
                };
            }

            var baseDirectory = App.FileManager.GetBaseDirectory("Client");

            ElementRenderer.VisualizeImageInPanel(this.PictureBoxContainer, selectedClient.Name, baseDirectory);

            this.NameText.Text = selectedClient.Name;
            this.AgeText.Text = selectedClient.Age.ToString();
            this.AddressText.Text = selectedClient.Address;
            this.PhoneText.Text = selectedClient.MobileNumber;

            this.VizualizeClientOrders(selectedClient.Name);
        }

        public static void ChangeDataContextOfClientInfoContainer(Client client)
        {
            clientInfoContainer.DataContext = client;
        }

        private void ShowClientDescriptionImages()
        {
            this.NameImage.Visibility = System.Windows.Visibility.Visible;
            this.AddressImage.Visibility = System.Windows.Visibility.Visible;
            this.AgeImage.Visibility = System.Windows.Visibility.Visible;
            this.PhoneImage.Visibility = System.Windows.Visibility.Visible;
        }

        private void HideClientDescriptionImages()
        {
            this.NameImage.Visibility = System.Windows.Visibility.Hidden;
            this.AddressImage.Visibility = System.Windows.Visibility.Hidden;
            this.AgeImage.Visibility = System.Windows.Visibility.Hidden;
            this.PhoneImage.Visibility = System.Windows.Visibility.Hidden;
        }

        void VizualizeClientOrders(string clientName)
        {
            IList<string> userOrders = App.FileManager.GetUserOrdersInfo(clientName);

            this.ClientStockItems.Children.Clear();

            if (userOrders.Count > 0)
            {
                this.ClientStockItems.Background = Brushes.White;
            }
            else
            {
                this.ClientStockItems.Background = Brushes.Gray;
            }

            foreach (var orderInfo in userOrders)
            {
                var components = orderInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                Grid newItemGrid = new Grid();
                newItemGrid.Margin = new Thickness(5, 5, 0, 10);
                newItemGrid.Height = 50;

                var imageColumn = new ColumnDefinition();
                imageColumn.Width = new GridLength(50);

                newItemGrid.ColumnDefinitions.Add(imageColumn);
                newItemGrid.ColumnDefinitions.Add(new ColumnDefinition());

                ElementRenderer.VisualizeImageInPanel(
                    newItemGrid, components[1], App.FileManager.GetBaseDirectory(components[0]));

                var textBlock = new TextBlock();
                textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                textBlock.Margin = new Thickness(5, 0, 0, 0);
                textBlock.FontSize = 15;

                textBlock.Text = string.Format("{0} [{1}] ", components[1], components[2]);

                if (components[0] == "Game" || components[0] == "Music")
                {
                    textBlock.Text += string.Format("| Price: {0:C}", decimal.Parse(components[3]));
                }
                else if (components[0] == "Movie")
                {
                    textBlock.Text += string.Format("| Rented: {0} - {1} | Price: {2:C}",
                        components[3], components[4], decimal.Parse(components[5]));
                }

                Grid.SetColumn(textBlock, 1);
                newItemGrid.Children.Add(textBlock);

                this.ClientStockItems.Children.Add(newItemGrid);
            }
        }

        private void OnMakeOrderButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                App.FileManager.MakeClientOrder(sender.ToString(), Basket.GetAllOrders());

                App.Resources.MovieOrdersCount =
                    App.FileManager.SetStatisticInfo(App.FileManager.GetBaseDirectory("Movie"),
                        Basket.RentedItems.Count);

                App.Resources.GameOrdersCount =
                    App.FileManager.SetStatisticInfo(App.FileManager.GetBaseDirectory("Game"),
                        Basket.PurchasedItems.Where(i => i is Game).Count());

                App.Resources.MusicOrdersCount =
                    App.FileManager.SetStatisticInfo(App.FileManager.GetBaseDirectory("Music"),
                        Basket.PurchasedItems.Where(i => i is Music).Count());

                App.Resources.TotalIncome =
                    App.FileManager.SetStatisticInfo(App.FileManager.GetBaseDirectory("Library"),
                        Basket.PurchasedItems.Sum(i => i.Price) + Basket.RentedItems.Sum(i => i.TotalPrice), "total-income");

                Basket.EmptyBasket();
                this.ClientInfoContainer_DataContextChanged(null, new DependencyPropertyChangedEventArgs());
                this.ShowBasketItemsToGrid();
            }
            catch (Exception)
            {
                new ApplicationProccessException();
            }
        }

        #endregion

        #region [Basket Vizualization - Show/Add items]
        
        private void ShowBasketItemsToGrid()
        {
            if (Basket.PurchasedItems.Count > 0 || Basket.RentedItems.Count > 0)
            {
                this.BasketElementsScrollViewer.Visibility = System.Windows.Visibility.Visible;
                this.BasketElementsStackPanel.Visibility = System.Windows.Visibility.Visible;
                this.ClientsScrollViewer.Margin = new Thickness(10, 119, 650, 324);
                this.ClientsListBox.Height = 257;

                decimal totalPrice = 0m;

                foreach (var item in Basket.RentedItems)
                {
                    this.AddItemToBasketGrid(item as IDescription);
                    totalPrice += item.TotalPrice;
                }
                
                foreach (var item in Basket.PurchasedItems)
                {
                    this.AddItemToBasketGrid(item as IDescription);
                    totalPrice += item.Price;
                }

                StackPanel priceAndResetButtonStackPanel = new StackPanel();
                priceAndResetButtonStackPanel.Margin = new Thickness(5, 0, 5, 5);

                TextBlock totalPriceTextBlock = new TextBlock();
                totalPriceTextBlock.Margin = new Thickness(0, 0, 5, 5);
                totalPriceTextBlock.FontWeight = FontWeights.Bold;
                totalPriceTextBlock.FontSize = 14;
                totalPriceTextBlock.Text = string.Format("Total price: {0:C}", totalPrice);   

                Button resetButton = new Button();
                resetButton.Content = "Empty Basket";
                resetButton.Height = 20;

                priceAndResetButtonStackPanel.Children.Add(totalPriceTextBlock);        
                priceAndResetButtonStackPanel.Children.Add(resetButton);
                
                resetButton.Click += (sender, args) =>
                {
                    Basket.EmptyBasket();              
                    this.ShowBasketItemsToGrid();
                };
                
                this.BasketElementsStackPanel.Children.Add(priceAndResetButtonStackPanel);
            }
            else
            {
                this.MakeOrderButton.Visibility = System.Windows.Visibility.Hidden;
                this.BasketElementsScrollViewer.Visibility = System.Windows.Visibility.Hidden;
                this.BasketElementsStackPanel.Visibility = System.Windows.Visibility.Hidden;
                this.ClientsScrollViewer.Margin = new Thickness(10, 119, 650, 10);
                this.ClientsListBox.Height = 571;
            }
        }
        
        private void AddItemToBasketGrid(IDescription itemDescription)
        {
            Grid newItemGrid = new Grid();
            newItemGrid.Margin = new Thickness(5, 0, 0, 10);
            newItemGrid.Height = 50;
            
            var imageColumn = new ColumnDefinition();
            imageColumn.Width = new GridLength(50);
            
            newItemGrid.ColumnDefinitions.Add(imageColumn);
            newItemGrid.ColumnDefinitions.Add(new ColumnDefinition());
            
            ElementRenderer.VisualizeImageInPanel(
                newItemGrid, itemDescription.Name, App.FileManager.GetBaseDirectory(itemDescription.GetType().Name));
            
            var textBlock = new TextBlock();
            textBlock.Text = itemDescription.Name;
            textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            textBlock.Margin = new Thickness(5, 0, 0, 0);
            textBlock.FontSize = 15;
            
            Grid.SetColumn(textBlock, 1);
            newItemGrid.Children.Add(textBlock);
            
            this.BasketElementsStackPanel.Children.Add(newItemGrid);
        }
        
        #endregion

        #region [WINDOW events - Close / Minimize / Moving / Closing / VisibleChanged]
        
        private void MoveTheWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Closing -= this.Window_Closing;
            e.Cancel = true;
            
            DoubleAnimation animation = ElementRenderer.WindowAnimation(this);
            
            this.BeginAnimation(Window.OpacityProperty, animation);
            
            animation.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, animation);
        }
        
        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        
        private void MinimazeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DoubleAnimation animation = ElementRenderer.WindowAnimation(this, 0, 1);
        
            this.BeginAnimation(Window.OpacityProperty, animation);
        }
        
        private void ToMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        
        #endregion
        
        #region [Set/Unset color of Labels and Boxes - using OnHover and OnLeave Events]
        
        static readonly Brush lineOnHoverColor = Brushes.GhostWhite;
        static readonly Brush lineOnLeaveColor = Brushes.CornflowerBlue;
        
        private void ToMainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.TopLeftRectangle.Fill = lineOnLeaveColor;
        }
        
        private void ToMainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            this.TopLeftRectangle.Fill = this.Background;
        }
        
        #endregion
        
        #region [Search box & Button Events]
        
        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            ElementRenderer.VizualizeNewClientsSearchResult(
                this.ClientsListBox, this.InfoAboutClientGrid, this.SearchByNameBox, App.Resources.Clients);
        }
        
        private void OnSearchBoxGotFocus(object sender, RoutedEventArgs e)
        {
            ElementRenderer.SearchBoxRemoveContent(this.SearchByNameBox);
        }
        
        private void OnSearchBoxLostFocus(object sender, RoutedEventArgs e)
        {
            ElementRenderer.SearchBoxPutContent(this.SearchByNameBox);
        }
        
        #endregion
    }
}