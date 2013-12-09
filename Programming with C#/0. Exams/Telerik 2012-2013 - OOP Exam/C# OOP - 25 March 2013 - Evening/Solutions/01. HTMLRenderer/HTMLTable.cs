namespace HTMLRenderer
{
    using System;
    using System.Linq;
    using System.Text;

    class HtmlTable : HtmlElement, ITable
    {
        private const string TableName = "table";
        private const string TableRowOpenTag = "<tr>";
        private const string TableRowCloseTag = "</tr>";
        private const string TableCellOpenTag = "<td>";
        private const string TableCellCloseTag = "</td>";

        private IElement[,] childElements;

        public HtmlTable(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;

            this.childElements = new IElement[this.Rows, this.Cols];
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public IElement this[int row, int col]
        {
            get { return this.childElements[row, col]; }
            set { this.childElements[row, col] = value; }
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", TableName);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TableRowOpenTag);

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TableCellOpenTag);
                    output.Append(this.childElements[row, col]);
                    output.Append(TableCellCloseTag);
                }

                output.Append(TableRowCloseTag);
            }

            output.AppendFormat("</{0}>", TableName);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            this.Render(output);

            return output.ToString();
        }
    }
}