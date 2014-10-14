namespace PrintYourName
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Index : Page
    {
        public void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            this.nameResultBox.Text = "Your name is: " + this.Server.HtmlEncode(this.nameTextBox.Text);
        }
    }
}