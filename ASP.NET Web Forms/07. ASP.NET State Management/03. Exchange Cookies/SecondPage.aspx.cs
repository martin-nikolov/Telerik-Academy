namespace _03.Exchange_Cookies
{
    using System;
    using System.Linq;
    using System.Web;

    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string item in this.Request.Cookies)
            {
                this.Literal.Text += this.Request.Cookies[item].Value + "<br/>";
            }
        }

        protected void OnButtonClicked(object sender, EventArgs e)
        {
            this.Response.AppendCookie(new HttpCookie(new Random().Next().ToString(), "Cookie Set from SecondPage.aspx"));
            this.Response.Redirect("FirstPage.aspx");
        }
    }
}