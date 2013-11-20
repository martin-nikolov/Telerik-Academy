using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MagicSquare
{
    public partial class MainWindow : Window
    {
        Matrix matrix = new Matrix();

        public MainWindow()
        {
            this.InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this.matrix;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void OnSubmitButtonClick(object sender, RoutedEventArgs e)
        {
            this.RefreshMatrixValues();

            if (this.matrix.IsValidMatrix())
            {
                MessageBox.Show("CORRECT!", "GENIUS", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("INCORRECT!", "BAD ASS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            this.matrix = new Matrix();
            this.ClearTextBoxesContent(this);
        }

        void ClearTextBoxesContent(DependencyObject obj)
        {
            TextBox textBox = obj as TextBox;

            this.DataContext = null;
            this.DataContext = this.matrix;

            if (textBox != null)
            {
                textBox.Text = string.Empty;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                this.ClearTextBoxesContent(VisualTreeHelper.GetChild(obj, i));
        }

        private void RefreshMatrixValues()
        {
            int.TryParse(this.R0_C0.Text, out this.matrix.matrix[0, 0]);
            int.TryParse(this.R0_C1.Text, out this.matrix.matrix[0, 1]);
            int.TryParse(this.R0_C2.Text, out this.matrix.matrix[0, 2]);
            int.TryParse(this.R1_C0.Text, out this.matrix.matrix[1, 0]);
            int.TryParse(this.R1_C1.Text, out this.matrix.matrix[1, 1]);
            int.TryParse(this.R1_C2.Text, out this.matrix.matrix[1, 2]);
            int.TryParse(this.R2_C0.Text, out this.matrix.matrix[2, 0]);
            int.TryParse(this.R2_C1.Text, out this.matrix.matrix[2, 1]);
            int.TryParse(this.R2_C2.Text, out this.matrix.matrix[2, 2]);
        }

        private void SetResultBoxValues()
        {
            // Change content of result boxex on ROWS
            FirstRowSum.Text = matrix.GetFirstRowSum() != 0 ? matrix.GetFirstRowSum().ToString() : string.Empty;
            SecondRowSum.Text = matrix.GetSecondRowSum() != 0 ? matrix.GetSecondRowSum().ToString() : string.Empty;
            ThirdRowSum.Text = matrix.GetThirdRowSum() != 0 ? matrix.GetThirdRowSum().ToString() : string.Empty;

            // Change content of result boxex on COLS
            FirstColSum.Text = matrix.GetFirstColSum() != 0 ? matrix.GetFirstColSum().ToString() : string.Empty;
            SecondColSum.Text = matrix.GetSecondColSum() != 0 ? matrix.GetSecondColSum().ToString() : string.Empty;
            ThirdColSum.Text = matrix.GetThirdColSum() != 0 ? matrix.GetThirdColSum().ToString() : string.Empty;

            // Change content of result boxex on DIAGONALS
            RightDownDiagonalSum.Text = matrix.RightDownDiagonal() != 0 ? matrix.RightDownDiagonal().ToString() : string.Empty;
            LeftDownDiagonalSum.Text = matrix.LeftDownDiagonal() != 0 ? matrix.LeftDownDiagonal().ToString() : string.Empty;

            // Change color of result boxes
            this.ChangeColorOfResultBoxes(this.ResultGridRows);
            this.ChangeColorOfResultBoxes(this.ResultGridCols);
        }

        void ChangeColorOfResultBoxes(DependencyObject obj)
        {
            var textBox = obj as TextBlock;

            if (textBox != null)
            {
                if (textBox.Text != "15")
                {
                    textBox.Foreground = Brushes.Red;
                }
                else
                {
                    textBox.Foreground = Brushes.Green;
                }
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                this.ChangeColorOfResultBoxes(VisualTreeHelper.GetChild(obj, i));
        }

        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {
            this.RefreshMatrixValues();
            this.SetResultBoxValues();
        }

        private void DragWindowOnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void MinimizeImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void AboutTextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("MAGIC QUADRAT ® CREATED BY MARTIN NIKOLOV", "ABOUT", MessageBoxButton.OK);
        }
    }
}