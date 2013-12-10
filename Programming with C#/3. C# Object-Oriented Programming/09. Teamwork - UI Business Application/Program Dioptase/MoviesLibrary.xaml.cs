namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using ProgramDioptase.CatalogItems;

    public partial class MoviesLibrary : Window
    {
        public MoviesLibrary()
        {
            this.InitializeComponent();
            ElementRenderer.VisualizeAllElementsToPanel<Movie>(this.AllMoviesPanel, App.Resources.Movies);
        }

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
            ElementRenderer.VizualizeNewSearchResultByName<Movie>(
                this.AllMoviesPanel, this.SearchByNameBox, App.Resources.Movies);
            ElementRenderer.ResetCheckBoxedGenredInExpander(this.GenrePanel);
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

        #region [Genres Expander -> CheckBoxes]
        
        private void OnCheckBoxSelection(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.SearchByNameBox.Text) && this.SearchByNameBox.Text != "Search by name")
            {
                ElementRenderer.VizualizeItemsBySelectedGenres(
                    this.AllMoviesPanel, this.GenrePanel, App.Resources.Movies, this.SearchByNameBox.Text);
            }
            else
            {
                ElementRenderer.VizualizeItemsBySelectedGenres(
                    this.AllMoviesPanel, this.GenrePanel, App.Resources.Movies);
            }
        }

        private void OnResetCheckBoxedGenresButtonClick(object sender, RoutedEventArgs e)
        {
            ElementRenderer.ResetCheckBoxedGenredInExpander(this.GenrePanel);
        }
        
        #endregion
    }
}