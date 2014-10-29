namespace NewsSystem.Web.Utility
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static string NormalizeText(this string content, int maxLength)
        {
            if (content.Length > maxLength)
            {
                return string.Format("{0}...", content.Substring(0, maxLength));
            }
            else
            {
                return content;
            }
        }
    }
}