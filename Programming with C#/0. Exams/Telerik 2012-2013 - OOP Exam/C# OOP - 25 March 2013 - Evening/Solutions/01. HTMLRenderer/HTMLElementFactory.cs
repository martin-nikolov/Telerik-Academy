namespace HTMLRenderer
{
    using System;
    using System.Linq;

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HtmlElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HtmlElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HtmlTable(rows, cols);
        }
    }
}