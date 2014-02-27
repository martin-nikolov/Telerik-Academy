using System;
using System.Threading;

namespace CodingPractice
{
	public static class DuplicatesInArray
	{
		public static void run()
		{
			int[] arr = {1, 3, 2, 5, 2, 1, 2, 2};
			int arr_size = arr.Length;
			printRepeating(arr, arr_size);
			Thread.Sleep(1000);
		}

		private static void printRepeating(int[] arr, int size)
		{
			Console.WriteLine("The Repeating numbers are");

			for (int i = 0; i < size; i++)
			{
				if (arr[Math.Abs(arr[i])] > 0)
				{
					arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
				}
				else
				{
					Console.WriteLine(Math.Abs(arr[i]));
				}
			}
		}
	}
}