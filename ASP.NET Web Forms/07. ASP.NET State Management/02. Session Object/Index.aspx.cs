namespace _02.Session_Object
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["values"] == null)
            {
                this.Session.Add("values", new List<string>());
            }
        }

        protected void OnButtonClicked(object sender, EventArgs e)
        {
            var list = (List<string>)this.Session["values"];
            list.Add(this.MainTextBox.Text);
            this.MainLabel.Text = string.Empty;

            foreach (var item in list)
            {
                this.MainLabel.Text += "<br/>" + item;
            }

            this.MainTextBox.Text = string.Empty;
        }
    }
}