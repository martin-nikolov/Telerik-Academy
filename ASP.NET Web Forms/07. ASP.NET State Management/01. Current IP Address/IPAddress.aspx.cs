namespace CurrentIpAddress
{
    using System;
    using System.Linq;

    public partial class IPAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MainLabel.Text = this.Request.UserAgent + "<br/>";
            this.MainLabel.Text += this.Request.UserHostAddress.ToString().Trim();
        }
    }
}