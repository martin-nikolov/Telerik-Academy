using System;

namespace CodingPractice.TernaryTree
{
	internal class Node
	{
		internal Node center;
		internal Node left;
		internal Node right;
		internal char m_char;
		internal bool wordEnd;

		public Node(char ch, bool wordEnd)
		{
			m_char = ch;
			this.wordEnd = wordEnd;
		}
	}

	public class TernaryTree
	{
		private Node root;

		private void Add(string s, int pos, ref Node node)
		{
			if (node == null)
			{
				node = new Node(s[pos], false);
			}

			if (s[pos] < node.m_char) //core logic. compare ip with curent node value.
			{
				Add(s, pos, ref node.left); // move left
			}
			else if (s[pos] > node.m_char) // move right
			{
				Add(s, pos, ref node.right);
			}
			else
			{
				if (pos + 1 == s.Length) //end of word
				{
					node.wordEnd = true;
				}
				else
				{
					// gerenal case 
					Add(s, pos + 1, ref node.center);
				}
			}
		}

		public void Add(string s)
		{
			if (String.IsNullOrEmpty(s)) throw new ArgumentException();
			Add(s, 0, ref root);
		}

		public bool Contains(string s)
		{
			if (String.IsNullOrEmpty(s)) throw new ArgumentException();

			int pos = 0;
			Node node = root;
			while (node != null)
			{
				if (s[pos] < node.m_char)
				{
					node = node.left;
				}
				else if (s[pos] > node.m_char)
				{
					node = node.right;
				}
				else
				{
					if (++pos == s.Length) return node.wordEnd;
					node = node.center;
				}
			}

			return false;
		}
	}
}