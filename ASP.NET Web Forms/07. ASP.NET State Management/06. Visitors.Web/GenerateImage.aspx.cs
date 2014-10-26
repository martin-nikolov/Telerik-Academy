namespace Visitors.Web
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using Visitors.Data;
    using Visitors.Models;

    public partial class GenerateImage : System.Web.UI.Page
    {
        private VisitorsDbContext visitorsDbContext = new VisitorsDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            var visits = this.GetOrSaveVisits();
            this.GenerateBitmap(visits);
        }
 
        private int GetOrSaveVisits()
        {
            var visits = this.visitorsDbContext.Visitors.FirstOrDefault();
            if (visits == null)
            {
                var newVisit = new Visitor()
                {
                    Count = 1
                };

                this.visitorsDbContext.Visitors.Add(newVisit);
                this.visitorsDbContext.SaveChanges();
                return newVisit.Count;
            }
            else
            {
                visits.Count++;
                this.visitorsDbContext.SaveChanges();
                return visits.Count;
            }
        }
 
        private void GenerateBitmap(int visits)
        {
            using (Bitmap bitmap = new Bitmap(110, 110))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.FillRectangle(Brushes.Black, 0, 0, 200, 200);
                    graphics.DrawString(visits.ToString(),
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