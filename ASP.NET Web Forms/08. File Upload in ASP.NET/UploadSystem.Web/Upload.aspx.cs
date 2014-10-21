namespace UploadSystem.Web
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI;
    using Ionic.Zip;
    using UploadSystem.Data;
    using UploadSystem.Models;
 
    public partial class Upload : Page
    {
        private UploadSystemDbContext uploadSystemDbContext = new UploadSystemDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Expires = -1;

            try
            {
                var fileStream = this.Request.Files["uploaded"].InputStream;

                using (var archive = ZipFile.Read(fileStream))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            var memoryStream = new MemoryStream();
                            var streamReader = new StreamReader(memoryStream);

                            entry.Extract(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);

                            var zipFileContent = streamReader.ReadToEnd();
                            this.uploadSystemDbContext.ZipFileContent.Add(new ZipFileContent()
                            {
                                Content = zipFileContent
                            });

                            this.uploadSystemDbContext.SaveChanges();
                        }
                    }
                }

                this.Response.ContentType = "application/json";
                this.Response.Write("{}");
            }
            catch (Exception ex)
            {
                this.Response.Write(ex.ToString());
            }
        }
    }
}