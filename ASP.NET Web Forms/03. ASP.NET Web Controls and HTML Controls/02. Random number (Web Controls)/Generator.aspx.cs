namespace RandomNumberWebControls
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Generator : Page
    {
        private static Random randomNumberGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnGenerateRandomNumberButtonClicked(object sender, EventArgs e)
        {
            int minNumber;
            int.TryParse(this.minNumberInput.Text, out minNumber);

            int maxNumber;
            int.TryParse(this.maxNumberInput.Text, out maxNumber);

            var randomNumber = randomNumberGenerator.Next(minNumber, maxNumber + 1);
            this.randomNumberContainer.InnerText = string.Format("Random number: {0}", randomNumber.ToString());
        }
    }
}