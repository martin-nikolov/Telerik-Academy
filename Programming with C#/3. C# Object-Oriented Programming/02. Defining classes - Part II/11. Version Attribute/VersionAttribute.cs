using System;
using System.Linq;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
                    AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]

    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(string version)
        {
            this.Version = version;
        }

        public string Version { get; private set; }

        public override string ToString()
        {
            return this.Version;
        }
    }
}