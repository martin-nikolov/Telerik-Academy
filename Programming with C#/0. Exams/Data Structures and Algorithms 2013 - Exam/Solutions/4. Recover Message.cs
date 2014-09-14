using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RecoverMessage
{
    private static readonly IDictionary<char, Node> graph = new SortedDictionary<char, Node>();
    private static readonly StringBuilder output = new StringBuilder();

    internal static void Main()
    {
        int messagesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < messagesCount; i++)
        {
            var message = Console.ReadLine();
            var parentNode = GetOrCreateNode(message[0]);

            for (int j = 1; j < message.Length; j++)
            {
                var childNode = GetOrCreateNode(message[j]);
                parentNode.Children.Add(childNode);
                childNode.Parents.Add(parentNode);
                parentNode = childNode;
            }
        }

        RecoverMessageTopologicalSorting();
        Console.WriteLine(output);
    }
 
    private static void RecoverMessageTopologicalSorting()
    {
        while (graph.Count > 0)
        {
            var parentNode = graph.Values.First(a => a.Parents.Count == 0);
            output.Append(parentNode.Key);

            foreach (var child in parentNode.Children)
            {
                child.Parents.Remove(parentNode);
            }

            graph.Remove(parentNode.Key);
        }
    }

    private static Node GetOrCreateNode(char key)
    {
        Node node;
        graph.TryGetValue(key, out node);

        if (node == null)
        {
            node = new Node(key);
            graph[key] = node;
        }

        return node;
    }

    public class Node : IComparable<Node>
    {
        public Node(char key)
        {
            this.Key = key;
            this.Parents = new SortedSet<Node>();
            this.Children = new SortedSet<Node>();
        }

        public char Key { get; set; }

        public SortedSet<Node> Parents { get; set; }

        public SortedSet<Node> Children { get; set; }

        public int CompareTo(Node other)
        {
            return this.Key.CompareTo(other.Key);
        }

        public override string ToString()
        {
            return this.Key.ToString();
        }
    }
}