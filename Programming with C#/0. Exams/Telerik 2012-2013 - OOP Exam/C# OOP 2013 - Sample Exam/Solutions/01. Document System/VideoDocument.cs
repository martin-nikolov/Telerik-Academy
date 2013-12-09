namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class VideoDocument : MultimediaDocument
    {
        public long? FrameRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("framerate"))
            {
                this.FrameRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));

            base.SaveAllProperties(output);
        }
    }
}