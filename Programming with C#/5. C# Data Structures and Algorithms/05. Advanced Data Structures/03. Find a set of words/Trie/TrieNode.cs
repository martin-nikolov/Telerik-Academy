using System.Collections.Generic;

namespace rmandvikar.Trie
{
    /// <summary>
    /// TrieNode is an internal object to encapsulate recursive, helper etc. methods. 
    /// </summary>
    internal class TrieNode
    {
        #region data members
        
        /// <summary>
        /// The character for the TrieNode.
        /// </summary>
        internal char Character { get; private set; }
        
        /// <summary>
        /// Children Character->TrieNode map.
        /// </summary>
        internal IDictionary<char, TrieNode> Children { get; private set; }
        
        /// <summary>
        /// Boolean to indicate whether the root to this node forms a word.
        /// </summary>
        internal bool IsWord { get; set; }
        
        /// <summary>
        /// The count of words for the TrieNode.
        /// </summary>
        internal int WordCount { get; set; }
        
        #endregion
        
        #region constructors
        
        /// <summary>
        /// Constructor for character.
        /// </summary>
        /// <param name="character">The character for the TrieNode.</param>
        /// <param name="children">Children of TrieNode.</param>
        /// <param name="isWord">If root TrieNode to this TrieNode is a word.</param>
        /// <param name="wordCount"></param>
        internal TrieNode(char character, IDictionary<char, TrieNode> children,
            bool isWord, int wordCount)
        {
            this.Character = character;
            this.Children = children;
            this.IsWord = isWord;
            this.WordCount = wordCount;
        }
        
        #endregion
        
        #region methods
        
        /// <summary>
        /// For readability.
        /// </summary>
        /// <returns>Character.</returns>
        public override string ToString()
        {
            return this.Character.ToString();
        }
        
        public override bool Equals(object obj)
        {
            TrieNode that;
            return
                  obj != null &&
                  (that = obj as TrieNode) != null &&
                  that.Character == this.Character;
        }
        
        public override int GetHashCode()
        {
            return this.Character.GetHashCode();
        }
        
        #endregion
    }
}