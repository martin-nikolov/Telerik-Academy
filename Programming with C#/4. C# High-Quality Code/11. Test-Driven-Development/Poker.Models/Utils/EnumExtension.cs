namespace Poker.Models.Utils
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    public static class EnumExtension
    {
        public static string Description(this Enum value)
        {
            var element = (DescriptionAttribute[])
            (
                value.GetType().GetField(value.ToString())).
            GetCustomAttributes(typeof(DescriptionAttribute), false);

            return element.Length > 0 ? element[0].Description : value.ToString();
        }
    }
}