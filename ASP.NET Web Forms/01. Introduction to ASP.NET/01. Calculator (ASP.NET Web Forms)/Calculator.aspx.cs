namespace CalculatorWebForms
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Calculator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.resultTextBlock.Text = "0";
        }

        protected void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            double firstNumber;
            double.TryParse(this.firstNumberInput.Value, out firstNumber);
            this.firstNumberInput.Value = firstNumber.ToString();

            double secondNumber;
            double.TryParse(this.secondNumberInput.Value, out secondNumber);
            this.secondNumberInput.Value = secondNumber.ToString();

            var result = firstNumber + secondNumber;
            this.resultTextBlock.Text = result.ToString();
        }
    }
}