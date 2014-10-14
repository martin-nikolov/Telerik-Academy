namespace WebFormAppModel
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mainTextBlock.Text = "Hello, ASP.NET";
            this.locationTextBlock.Text = "Location: " + Assembly.GetExecutingAssembly().Location;
        }
    }
}