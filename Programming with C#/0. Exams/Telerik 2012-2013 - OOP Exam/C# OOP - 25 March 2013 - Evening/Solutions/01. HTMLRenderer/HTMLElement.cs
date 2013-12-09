namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class HtmlElement : IElement
    {
        private ICollection<IElement> childElements;

        public HtmlElement(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public HtmlElement(string name, string textContent)
            : this(name)
        {
            this.TextContent = textContent;
        }

        public string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get { return this.childElements; }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            output.AppendFormat(!string.IsNullOrEmpty(this.Name) ? "<" + this.Name + ">" : string.Empty);

            output.Append(!string.IsNullOrEmpty(this.TextContent) ? this.Encode(this.TextContent) : string.Empty);

            foreach (var child in this.ChildElements)
            {
                child.Render(output);
            }

            output.AppendFormat(!string.IsNullOrEmpty(this.Name) ? "</" + this.Name + ">" : string.Empty);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            this.Render(output);

            return output.ToString();
        }

        protected string Encode(string textContent)
        {
            return textContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}