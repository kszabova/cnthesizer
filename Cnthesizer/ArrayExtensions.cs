using System;

namespace Cnthesizer
{
	public static class ArrayExtensions
	{
		/// <summary>
		/// Duplicate array elements into a new array until a desired length is reached.
		/// If length is less than source array, new array won't contain all elements.
		/// </summary>
		/// <typeparam name="T">Type of elements in array</typeparam>
		/// <param name="source">Array from which elements will be copied</param>
		/// <param name="length">Length of new array</param>
		/// <returns></returns>
		public static T[] MultiplyToLength<T>(this T[] source, int length)
		{
			if (source.Length == 0) return new T[length];

			int srcLength = source.Length;
			int fullCopies = length / source.Length;
			int remainder = length % source.Length;

			T[] multiplied = new T[length];
			// copy entire array into the result as many times as it fits
			for (int i = 0; i < fullCopies; i++)
			{
				Array.Copy(source, 0, multiplied, i * srcLength, srcLength);
			}
			// copy the remainder
			Array.Copy(source, 0, multiplied, fullCopies * srcLength, remainder);

			return multiplied;
		}
	}
}