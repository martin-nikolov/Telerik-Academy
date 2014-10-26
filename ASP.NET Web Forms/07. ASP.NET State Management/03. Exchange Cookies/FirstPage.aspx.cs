namespace _03.Exchange_Cookies
{
    using System;
    using System.Linq;
    using System.Web;

    public partial class FirstPage : System.Web.UI.Page
    {
        protected void OnButtonClicked(object sender, EventArgs e)
        {
            this.Response.AppendCookie(new HttpCookie(new Random().Next().ToString(), "Cookie Set from FirstPage.aspx"));
            this.Response.Redirect("SecondPage.aspx");
        }
    }
}