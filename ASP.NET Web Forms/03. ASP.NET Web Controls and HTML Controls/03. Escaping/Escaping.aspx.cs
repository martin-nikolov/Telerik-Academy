namespace EscapingHtml
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Escaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var enteredText = this.mainTextBox.Text;

            this.enteredTextBox.Text = enteredText; // this.Server.HtmlEncode(enteredText);
            this.enteredTextLabel.Text = this.Server.HtmlEncode(enteredText);
        }
    }
}