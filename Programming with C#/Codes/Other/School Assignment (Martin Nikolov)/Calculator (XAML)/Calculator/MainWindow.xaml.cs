using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double resultHistory = 0;

        string currentSign = "";

        public MainWindow()
        {
            this.InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.InputValueBox.Focus();
        }

        private void OnNumericButtonClick(object sender, RoutedEventArgs e)
        {
            this.ChangeResultBoxContent(sender as Button);
            this.InputValueBox.Focus();
        }

        private void ChangeResultBoxContent(Button sender)
        {
            if (this.InputValueBox.Text.Length < this.InputValueBox.MaxLength)
            {
                this.InputValueBox.Text += sender.Content;

                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                this.ChangeResult(value.ToString());
            }
        }

        private void OnClearButtonClick(object sender, RoutedEventArgs e)
        {
            this.InputValueBox.Text = "0";
            this.InputValueBox.Focus();
        }

        private void OnClearLastDigitClick(object sender, RoutedEventArgs e)
        {
            if (this.InputValueBox.Text.Length > 0)
            {
                this.InputValueBox.Text = this.InputValueBox.Text.Substring(0, this.InputValueBox.Text.Length - 1);
            }

            this.InputValueBox.Focus();
        }

        private void OnSqrtButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.InputValueBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                if (value >= 0)
                {
                    value = Math.Sqrt(value);
                    this.ChangeResult(value.ToString());
                }
                else
                {
                    this.InputValueBox.Text = "0";
                }

                this.InputValueBox.Focus();
            }
        }

        private void OnChangeSignClick(object sender, RoutedEventArgs e)
        {
            if (this.InputValueBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                if (value >= 0)
                {
                    value = -value;
                    this.ChangeResult(value.ToString(), "{0}");
                }
                else
                {
                    this.InputValueBox.Text = "0";
                }

                this.InputValueBox.Focus();
            }
        }

        private void OnDiviseOfOneClick(object sender, RoutedEventArgs e)
        {
            if (this.InputValueBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                if (value >= 0)
                {
                    value = 1 / value;
                    this.ChangeResult(value.ToString());
                }
                else
                {
                    this.InputValueBox.Text = "0";
                }

                this.InputValueBox.Focus();
            }
        }

        private void ChangeResult(string result, string format = "{0}")
        {
            this.InputValueBox.Text = string.Format(format, result);
        }

        private void OnCommaClick(object sender, RoutedEventArgs e)
        {
            if (this.InputValueBox.Text.Length > 0 && this.InputValueBox.Text.IndexOf('.') == -1)
            {
                this.InputValueBox.Text += '.';

                this.InputValueBox.Focus();
            }
        }

        private void OnDiviseOfXClick(object sender, RoutedEventArgs e)
        {
            this.MakeCalcalation("/");
        }

        private void OnMultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            this.MakeCalcalation("*");
        }

        private void OnMinusButtonClick(object sender, RoutedEventArgs e)
        {
            this.MakeCalcalation("-");
        }

        private void OnPlusButtonClick(object sender, RoutedEventArgs e)
        {
            this.MakeCalcalation("+");
        }

        private void MakeCalcalation(string sign)
        {
            this.currentSign = sign;

            if (resultHistory != 0 && this.InputValueBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                switch (sign)
                {
                    case "+": resultHistory += value; break;
                    case "-": resultHistory -= value; break;
                    case "*": resultHistory *= value; break;
                    case "/": resultHistory /= value; break;
                    default: return;
                }

                this.ResultHistory.Text = resultHistory.ToString() + string.Format(" {0} ", sign);
                this.InputValueBox.Text = resultHistory.ToString();
            }
            else if (this.InputValueBox.Text.Length > 0)
            {
                resultHistory = 0;
                double.TryParse(this.InputValueBox.Text, out resultHistory);

                this.ResultHistory.Text = resultHistory.ToString() + string.Format(" {0} ", sign);
                this.InputValueBox.Text = string.Empty;
            }

            this.InputValueBox.Focus();
        }

        private void OnCalculateExpressionClick(object sender, RoutedEventArgs e)
        {
            if (resultHistory != 0 && this.InputValueBox.Text.Length > 0)
            {
                double value = 0;
                double.TryParse(this.InputValueBox.Text, out value);

                switch (this.currentSign)
                {
                    case "+": resultHistory += value; break;
                    case "-": resultHistory -= value; break;
                    case "*": resultHistory *= value; break;
                    case "/": resultHistory /= value; break;
                    default: return;
                }

                this.currentSign = string.Empty;

                this.ResultHistory.Text += this.InputValueBox.Text;
                this.InputValueBox.Text = resultHistory.ToString();

                resultHistory = 0;

                this.InputValueBox.Focus();
            }
        }

        private void OnClearAllResultClick(object sender, RoutedEventArgs e)
        {
            resultHistory = 0;
            this.InputValueBox.Text = "0";
            this.ResultHistory.Text = "0";

            this.InputValueBox.Focus();
        }

        private void InputValueBox_LayoutUpdated(object sender, EventArgs e)
        {
            this.InputValueBox.Text = this.InputValueBox.Text.Replace(',', '.');

            if (this.InputValueBox.Text.Count(ch => ch == '.') > 1)
            {
                this.OnClearLastDigitClick(sender, null);
            }
            
            if (this.InputValueBox.Text.Length > 0)
            {
                this.InputValueBox.CaretIndex = this.InputValueBox.Text.Length;
                // this.InputValueBox.Text = double.Parse(this.InputValueBox.Text).ToString();
            }
        }
    }
}