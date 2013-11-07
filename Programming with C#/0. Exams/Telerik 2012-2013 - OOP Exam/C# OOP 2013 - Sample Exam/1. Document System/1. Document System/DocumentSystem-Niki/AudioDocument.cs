using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        public int SampleRate
        {
            get
            {
                return this.GetProperty("SampleRate").ToInteger();
            }
            set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }
    }
}
