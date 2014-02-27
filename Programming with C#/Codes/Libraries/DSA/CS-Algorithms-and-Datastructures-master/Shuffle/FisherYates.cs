using System;
using System.Threading;

namespace CodingPractice.Shuffle
{
	public class FisherYates
	{
		public static void run()
		{
			int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9};

			Shuffle(arr);
			Console.WriteLine((string.Join(",", arr)));
			Thread.Sleep(800);
		}

		private static void Shuffle(int[] arr)
		{
			var rand = new Random();

			for (int i = arr.Length - 1; i > 0; i--)
			{
				int n = rand.Next(i);
				int temp = arr[i];
				arr[i] = arr[n];
				arr[n] = temp;
			}
		}
	}
}