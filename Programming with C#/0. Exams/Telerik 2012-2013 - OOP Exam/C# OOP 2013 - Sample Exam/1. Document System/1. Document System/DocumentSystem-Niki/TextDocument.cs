using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get
            {
                return this.GetProperty("chars").ToString();
            }
            set
            {
                this.LoadProperty("chars", value.ToString());
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
