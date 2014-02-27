using System;
using System.Threading;

namespace CodingPractice.Recursion
{
	public class Combinations
	{
		public static void run()
		{
			Console.WriteLine(combinations(20, 5));

			Thread.Sleep(1000);
		}

		private static int combinations(int group, int member)
		{
			if (member == 1)
				return group;
			else if (member == group)
				return 1;
			else
				return combinations(group - 1, member - 1) + combinations(group - 1, member);
		}
	}
}