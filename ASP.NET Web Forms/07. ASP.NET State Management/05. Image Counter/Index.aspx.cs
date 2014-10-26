namespace _05.Image_Counter
{
    using System;
    using System.Linq;
    using System.Web.UI;

    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Controls.Add(new LiteralControl("<img src=\"GenerateImage.aspx\" />"));
        }
    }
}