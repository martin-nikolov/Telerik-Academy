namespace ProcessingJson.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using ProcessingJson.Contracts;

    public class HtmlPageGenerator
    {
        private const string ItemTemplateFormat = "<li><a href=\"{0}\"><strong>[{1}]</strong> {2}</a></li>"; 

        public void CreateHtmlPage(string path, IList<IListItem> listItems)
        {
            var html = this.GenerateHtml(listItems);
            this.CreateFile(path, html);
        }
 
        private string GenerateHtml(IList<IListItem> listItems)
        {
            var html = new StringBuilder();
            html.AppendLine("<ul>");

            foreach (var listItem in listItems)
            {
                html.AppendFormat(ItemTemplateFormat, listItem.Link, listItem.Category, listItem.Title);
            }

            html.AppendLine("<ul>");
            return html.ToString();
        }

        private void CreateFile(string path, string html)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(html);
                }
            }
        }
    }
}