namespace SubstringModule.Services
{
    using System;
    using System.Linq;

    public class SubstringService : ISubstringService
    {
        public int GetNumberOfSubstrings(string text, string substring)
        {
            int count = 0, index = text.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(substring, index + substring.Length); // or index = text.IndexOf(substring, index + 1);
            }

            return count;
        }
    }
}