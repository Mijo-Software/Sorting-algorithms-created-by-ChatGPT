using System.Diagnostics;

namespace BounceSort
{
	public class BounceSort
	{
		public static void Main()
		{
			int[] array = GenerateRandomArray(length: 10000);

			Console.WriteLine(value: "Unsorted Array:");
			PrintArray(array: array);

			Stopwatch stopwatch = new();
			stopwatch.Start();

			BounceSortArray(array: array);

			stopwatch.Stop();

			Console.WriteLine(value: "Sorted Array:");
			PrintArray(array: array);

			Console.WriteLine(value: $"Sort time: {stopwatch.ElapsedMilliseconds} milliseconds");
		}

		private static void BounceSortArray<T>(T[] array) where T : IComparable<T>
		{
			int n = array.Length;
			int left = 0;
			int right = n - 1;

			while (left < right)
			{
				int newRight = left;
				int newLeft = right;

				for (int i = left; i < right; i++)
				{
					if (array[i].CompareTo(other: array[i + 1]) > 0)
					{
						Swap(array: array, i: i, j: i + 1);
						newRight = i;
					}
				}

				right = newRight;

				for (int i = right; i > left; i--)
				{
					if (array[i].CompareTo(other: array[i - 1]) < 0)
					{
						Swap(array: array, i: i, j: i - 1);
						newLeft = i;
					}
				}

				left = newLeft;
			}
		}

		private static void Swap<T>(T[] array, int i, int j)
		{
			if (i == j)
			{
				return;
			}

			(array[j], array[i]) = (array[i], array[j]);
		}

		private static void PrintArray<T>(T[] array)
		{
			foreach (T element in array)
			{
				Console.Write(value: $"{element} ");
			}
			Console.WriteLine();
		}

		private static int[] GenerateRandomArray(int length)
		{
			Random random = new();
			int[] array = new int[length];

			for (int i = 0; i < length; i++)
			{
				array[i] = random.Next(maxValue: 1000);
			}

			return array;
		}
	}
}