namespace TextToImageHttpHandler
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// You can generate image at address:
    /// http://localhost:4444/example.img?text=sample%20text
    /// </summary>
    /// <remarks>
    /// For more info:
    /// http://www.hanselman.com/blog/ASPNETFuturesGeneratingDynamicImagesWithHttpHandlersGetsEasier.aspx
    /// </remarks>
    public class TextToImage : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var content = context.Request.QueryString["text"];
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException("No text content specified.");
            }

            this.GenerateImage(context.Response, content, 500, 100, Color.Black,
                FontFamily.GenericSansSerif, 18, Brushes.BlueViolet, 0, 0, "image/png", ImageFormat.Png);
        }

        private void GenerateImage(HttpResponse response, string textToInsert, int width, int height, Color backgroundColor,
            FontFamily fontFamily, float emSize, Brush brush, float x, float y, string contentType, ImageFormat imageFormat)
        {
            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);
                    graphics.DrawString(textToInsert, new Font(fontFamily, emSize), brush, x, y);
                    response.ContentType = contentType;
                    bitmap.Save(response.OutputStream, imageFormat);
                }
            }
        }
    }
}