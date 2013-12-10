namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public partial class WindowStatistics : Window
    {
        public WindowStatistics()
        {
            this.InitializeComponent();

            try
            {
                this.MoviesOrderCount.Text = App.Resources.MovieOrdersCount.ToString();
                this.GamesOrderCount.Text = App.Resources.GameOrdersCount.ToString();
                this.MusicOrderCount.Text = App.Resources.MusicOrdersCount.ToString();

                this.TotalIncomeTextBlock.Text = string.Format("{0:C}", App.Resources.TotalIncome);
            }
            catch (Exception)
            {
                this.Show();
                new ApplicationProccessException();
            }
        }

        #region [WINDOW events - Close / Minimize / Moving / Closing / VisibleChanged]
        
        private void ToMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            this.Close();
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        
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
        
        private void ToMainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            this.TopLeftRectangle.Fill = lineOnLeaveColor;
        }
        
        private void ToMainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            this.TopLeftRectangle.Fill = this.Background;
        }
        
        #endregion
    }
}