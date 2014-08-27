namespace DatabaseConnectionsAdoNet
{
    using System;
    using System.Linq;
    using System.Text;

    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public string ISBN { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("   Book: " + this.Title);
            result.AppendLine("      - Author: " + this.Author);

            if (this.PublishDate != null)
            {
                result.AppendLine("      - Publish date: " + this.PublishDate.Value.ToLongDateString());
            }

            if (!string.IsNullOrEmpty(this.ISBN))
            {
                result.AppendLine("      - ISBN: " + this.ISBN);
            }

            return result.ToString();
        }
    }
}