using System;

namespace CodingPractice.TernaryTree
{
    public static class TernaryTreeRunner
    {
        public static void run()
        {
            var tree = new TernaryTree();
			tree.Add("rat");
			tree.Add("rate");
			tree.Add("rum");
            Console.WriteLine(tree.Contains("rate"));
        }
    }
}