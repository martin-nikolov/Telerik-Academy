namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
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

        #endregion

        #region [Set/Unset color of Labels and Boxes - using OnHover and OnLeave Events]

        static readonly Brush lineOnHoverColor = Brushes.GhostWhite;
        static readonly Brush lineOnLeaveColor = Brushes.CornflowerBlue;
             
        static readonly Brush boxOnHoverColor = Brushes.CornflowerBlue;
        static readonly Brush boxOnLeaveColor = Brushes.Lavender;
        
        private void MoviesLabel_MouseMove(object sender, RoutedEventArgs e)
        {
            this.TopLine.Fill = lineOnHoverColor;
        }
        
        private void MoviesLabel_MouseLeave(object sender, RoutedEventArgs e)
        {
            this.TopLine.Fill = lineOnLeaveColor;
        }
        
        private void GamesLabel_MouseMove(object sender, MouseEventArgs e)
        {
            this.MiddleLine.Fill = lineOnHoverColor;
        }
        
        private void GamesLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            this.MiddleLine.Fill = lineOnLeaveColor;
        }
        
        private void MusicLabel_MouseMove(object sender, MouseEventArgs e)
        {
            this.BottomLine.Fill = lineOnHoverColor;
        }
        
        private void MusicLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BottomLine.Fill = lineOnLeaveColor;
        }
        
        private void ClientsBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.ClientsBox.Fill = boxOnHoverColor;
        }
        
        private void ClientsBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.ClientsBox.Fill = boxOnLeaveColor;
        }
        
        private void StatisticsBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.StatisticsBox.Fill = boxOnHoverColor;
        }
        
        private void StatisticsBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.StatisticsBox.Fill = boxOnLeaveColor;
        }
        
        #endregion

        #region [Dispatching to Libraries]

        private void MoviesLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();

            MoviesLibrary moviesLibrary = new MoviesLibrary();
            moviesLibrary.Show();
        }

        private void GamesLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();

            GamesLibrary gamesLibrary = new GamesLibrary();
            gamesLibrary.Show();
        }

        private void MusicLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();

            MusicLibrary musicLibrary = new MusicLibrary();
            musicLibrary.Show();
        }

        private void ClientsBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();

            ClientsLibrary clientsLibrary = new ClientsLibrary();
            clientsLibrary.Show();
        }

        private void StatisticsBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();

            WindowStatistics statistics = new WindowStatistics();
            statistics.Show();
        }
        
        #endregion
    }
}