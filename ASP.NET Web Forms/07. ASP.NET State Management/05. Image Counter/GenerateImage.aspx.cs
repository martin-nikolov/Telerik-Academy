namespace _05.Image_Counter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;

    public partial class GenerateImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.IncreaseCounter();
            this.GenerateBitmap();
        }
 
        private void IncreaseCounter()
        {
            if (this.Session["visits"] == null)
            {
                this.Session.Add("visits", 1);
            }
            else
            {
                var numberOfVisits = (int)this.Session["visits"];
                this.Session["visits"] = ++numberOfVisits;
            }
        }
 
        private void GenerateBitmap()
        {
            using (Bitmap bitmap = new Bitmap(110, 110))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.FillRectangle(Brushes.Black, 0, 0, 200, 200);
                    graphics.DrawString(((int)this.Session["visits"]).ToString(),
                        new Font("Consolas", 40),
                        new SolidBrush(Color.White),
                        new PointF(30, 25));

                    this.Response.ContentType = "image/jpeg";
                    bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}