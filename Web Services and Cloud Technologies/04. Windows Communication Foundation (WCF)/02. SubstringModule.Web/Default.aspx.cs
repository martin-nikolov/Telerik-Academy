namespace SubstringModule.Web
{
    using System;
    using System.Web.UI;
    using SubstringModule.Web.ServiceSubstringModule;

    public partial class Default : Page
    {
        protected void OnGetNumberOfSubstringButtonClick(object sender, EventArgs e)
        {
            var client = new SubstringServiceClient();

            var text = this.TextBox.Text;
            var substring = this.SubStringTextBox.Text;
            this.ResultLabel.Text = "Number of substrings: " + client.GetNumberOfSubstrings(text, substring);
        }
    }
}