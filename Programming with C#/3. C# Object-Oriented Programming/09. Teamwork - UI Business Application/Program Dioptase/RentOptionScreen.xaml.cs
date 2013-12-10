namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using ProgramDioptase.CatalogItems;
    using ProgramDioptase.Interfaces.ItemDescription;
    using ProgramDioptase.Interfaces.ItemTypes;

    public partial class RentOptionScreen : Window
    {
        public RentOptionScreen()
        {
            this.InitializeComponent();

            this.RentedMovieInfo = new Movie();

            this.CalendarControl.DisplayDateStart = DateTime.Now;
            this.CalendarControl.DisplayDateEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 15);

            this.CalendarControl.Focusable = false;

            this.PeriodText = this.PeriodTextBlock.Text;
            this.TotalPriceText = this.TotalPriceTextBlock.Text;
        }

        public RentOptionScreen(IRentable item)
            : this()
        {
            this.Item = item;
            this.PricePerDayTextBlock.Text += string.Format("{0:C}", this.Item.PricePerDay);
        }

        public IRentable Item { get; set; }

        public object OldContent { get; set; }

        private string PeriodText { get; set; }

        private string TotalPriceText { get; set; }

        private Movie RentedMovieInfo { get; set; }

        #region [Windows events]

        private void MoveTheWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ToPreviousWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InformationAboutCatalogItem.Instance.Content = this.OldContent;
            this.Close();
        }

        #endregion

        #region [Set/Unset color Turn Back Button - using OnHover and OnLeave Events]

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

        private void CalendarControl_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.CalendarControl.BlackoutDates.Clear();

            if (this.CalendarControl.SelectedDate.HasValue)
            {
                DateTime today = DateTime.Now;
                DateTime selectedDate = this.CalendarControl.SelectedDate.Value;

                this.RentedMovieInfo.RentalDate = today;
                this.RentedMovieInfo.ReturnDate = selectedDate;

                if (today.Day != selectedDate.Day)
                {
                    TimeSpan span = selectedDate.Subtract(today);

                    decimal dayPriceOfItem = this.Item.PricePerDay;

                    this.PeriodTextBlock.Visibility = System.Windows.Visibility.Visible;
                    this.PeriodTextBlock.Text = string.Format("{0}{1} - {2}",
                        this.PeriodText, today.ToShortDateString(), selectedDate.AddDays(-1).ToShortDateString());

                    decimal totalPrice = (span.Days + 1) * dayPriceOfItem;
                    this.RentedMovieInfo.TotalPrice = totalPrice;

                    this.TotalPriceTextBlock.Visibility = System.Windows.Visibility.Visible;
                    this.TotalPriceTextBlock.Text = this.TotalPriceText + string.Format("{0:C}", totalPrice);

                    for (int i = 0; i <= span.Days; i++)
                    {
                        this.CalendarControl.BlackoutDates.Add(new System.Windows.Controls.CalendarDateRange(today));
                        today = today.AddDays(1);
                    }

                    this.AddToBasketButton.IsEnabled = true;
                }
            }
        }

        private void OnAddToBasketButtonClick(object sender, RoutedEventArgs e)
        {
            this.RentedMovieInfo.Name = (this.Item as IDescription).Name;
            this.RentedMovieInfo.ReleaseYear = (this.Item as IDescription).ReleaseYear;

            Basket.RentedItems.Add(this.RentedMovieInfo);
        }
    }
}