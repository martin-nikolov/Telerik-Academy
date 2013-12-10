namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using ProgramDioptase.Interfaces.ItemDescription;
    using ProgramDioptase.Interfaces.ItemTypes;

    public partial class InformationAboutCatalogItem : Window
    {
        public static InformationAboutCatalogItem Instance;

        public InformationAboutCatalogItem()
        {
            this.InitializeComponent();

            Instance = this;
        }

        public InformationAboutCatalogItem(IDescription catalogItem, Uri path)
            : this()
        {
            ElementRenderer.VisualizeImageInPanel(this.PictureBoxContainer, catalogItem.Name, path);

            this.NameText.Text = catalogItem.Name;
            this.GenreText.Text = string.Join(", ", catalogItem.Genres);
            this.YearText.Text = catalogItem.ReleaseYear;

            bool isInStock = (catalogItem as IStockable).IsInStock;
            this.IsInStockText.Text = isInStock ? "Available" : "Not Available";   
            this.IsInStockText.Foreground = isInStock ? Brushes.Green : Brushes.Red;

            Button stockButton = null;

            if (catalogItem is ISaleable)
            {
                this.PriceImage.Visibility = Visibility.Visible;
                this.SellPriceTextBlock.Text = string.Format("{0:C}", (catalogItem as ISaleable).Price);

                this.SellButton.Visibility = Visibility.Visible;
                stockButton = this.SellButton;

                // Set Click event to Sell Button
                this.SellButton.Click += (sender, args) =>
                {
                    Basket.PurchasedItems.Add(catalogItem as ISaleable);
                };
            }
            else if (catalogItem is IRentable)
            {
                this.PricePerDayImage.Visibility = Visibility.Visible;
                this.RentalPricePerDayTextBlock.Text = string.Format("{0:C}", (catalogItem as IRentable).PricePerDay);

                this.RentButton.Visibility = Visibility.Visible;
                stockButton = this.RentButton;
                
                // Set Click event to Rent Button
                this.RentButton.Click += (sender, args) =>
                {
                    RentOptionScreen rentScreen = new RentOptionScreen(catalogItem as IRentable);
                    rentScreen.OldContent = this.Content;
                    this.Content = rentScreen.Content;
                    this.DataContext = rentScreen.DataContext;
                };
            }

            if (stockButton != null && !isInStock)
            {
                stockButton.IsEnabled = false;
            }

            this.CloseButton.Focus();
        }
        
        #region [WINDOW events - Close / Minimize / Moving / Closing / VisibleChanged]

        private void MoveTheWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        
        #endregion  

        #region [Set/Unset color of Labels and Boxes - using OnHover and OnLeave Events]

        static readonly Brush lineOnHoverColor = Brushes.GhostWhite;
        static readonly Brush lineOnLeaveColor = Brushes.CornflowerBlue;

        private void ToMainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.BottomLeftRectangle.Fill = lineOnLeaveColor;
        }

        private void ToMainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BottomLeftRectangle.Fill = this.Background;
        }
        
        #endregion
    }
}