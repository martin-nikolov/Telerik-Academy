using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public static class ExtensionMethods
    {
        public static int ToInteger(this object obj)
        {
            int result = 0;
            int.TryParse(obj.ToString(), out result);
            return result;
        }

        public static ulong ToUnsignedLong(this object obj)
        {
            ulong result = 0;
            ulong.TryParse(obj.ToString(), out result);
            return result;
        }
    }
}
