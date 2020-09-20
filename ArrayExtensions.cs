using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public static class ArrayExtensions
	{
		public static T[] MultiplyToLength<T>(this T[] source, int length)
		{
			if (source.Length == 0) return new T[length];

			int srcLength = source.Length;
			int fullCopies = length / source.Length;
			int remainder = length % source.Length;

			T[] multiplied = new T[length];
			// copy entire array into the result
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
