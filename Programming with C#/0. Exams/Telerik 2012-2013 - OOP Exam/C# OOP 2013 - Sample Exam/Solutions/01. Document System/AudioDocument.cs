namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AudioDocument : MultimediaDocument
    {
        public long? SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.Equals("samplerate"))
            {
                this.SampleRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));

            base.SaveAllProperties(output);
        }
    }
}