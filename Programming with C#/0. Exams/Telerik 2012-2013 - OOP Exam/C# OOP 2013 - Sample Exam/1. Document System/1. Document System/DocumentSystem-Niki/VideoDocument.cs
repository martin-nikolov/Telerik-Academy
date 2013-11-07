using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        public int FrameRate 
        {
            get
            {
                return this.GetProperty("framerate").ToInteger();
            }
            set
            {
                this.LoadProperty("framerate", value.ToString());
            }
        }
    }
}
