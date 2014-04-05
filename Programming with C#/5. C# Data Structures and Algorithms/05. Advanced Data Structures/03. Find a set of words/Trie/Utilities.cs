namespace rmandvikar.Trie
{
    /// <summary>
    /// Helper methods.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Gets the word with the first character removed.
        /// </summary>
        public static char[] FirstCharRemoved(char[] word)
        {
            char[] cRemoved = null;
            if (word.Length > 0)
            {
                cRemoved = new char[word.Length - 1];
                for (var i = 1; i < word.Length; i++)
                {
                    cRemoved[i - 1] = word[i];
                }
            }
            return cRemoved;
        }

        /// <summary>
        /// Gets the first char of the word.
        /// </summary>
        public static char FirstChar(char[] word)
        {
            return word[0];
        }
    }
}