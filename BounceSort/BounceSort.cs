namespace BounceSort
{
	public class BounceSort
	{
		public static void Main()
		{
			int[] array = { 5, 8, 2, 1, 6, 3, 7, 4 };
			Console.WriteLine(value: "Unsorted Array:");
			PrintArray(array: array);
			BounceSortArray(array: array);
			Console.WriteLine(value: "Sorted Array:");
			PrintArray(array: array);
		}

		public static void BounceSortArray(int[] array)
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
					if (array[i] > array[i + 1])
					{
						Swap(array: array, i, i + 1);
						newRight = i;
					}
				}
				right = newRight;
				for (int i = right; i > left; i--)
				{
					if (array[i] < array[i - 1])
					{
						Swap(array: array, i, i - 1);
						newLeft = i;
					}
				}
				left = newLeft;
			}
		}

		public static void Swap(int[] array, int i, int j)
		{
			if (i == j)
			{
				return;
			}
			(array[j], array[i]) = (array[i], array[j]);
		}

		public static void PrintArray(int[] array)
		{
			foreach (int element in array)
			{
				Console.Write(value: element + " ");
			}
			Console.WriteLine();
		}
	}
}