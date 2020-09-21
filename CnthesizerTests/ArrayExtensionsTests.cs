using Cnthesizer;
using Xunit;

namespace CnthesizerTests
{
	public class ArrayExtensionsTests
	{
		[Fact]
		public void MultiplyToLength_ExactlyOneCopy()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(source.Length);
			Assert.Equal(source, result);
		}

		[Fact]
		public void MultiplyToLength_ExactlyTwoCopies()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(source.Length * 2);
			int[] expected = new int[] { 1, 2, 3, 1, 2, 3 };
			Assert.Equal(expected, result);
		}

		[Fact]
		public void MultiplyToLength_ShorterThanOne()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(source.Length - 1);
			int[] expected = new int[] { 1, 2 };
			Assert.Equal(expected, result);
		}

		[Fact]
		public void MultiplyToLength_LongerThanOne()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(source.Length + 1);
			int[] expected = new int[] { 1, 2, 3, 1 };
			Assert.Equal(expected, result);
		}

		[Fact]
		public void MultiplyToLength_LongerThanTwo()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(source.Length * 2 + 1);
			int[] expected = new int[] { 1, 2, 3, 1, 2, 3, 1 };
			Assert.Equal(expected, result);
		}

		[Fact]
		public void MultiplyToLength_Zero()
		{
			int[] source = new int[] { 1, 2, 3 };
			int[] result = source.MultiplyToLength(0);
			int[] expected = new int[] { };
			Assert.Equal(expected, result);
		}
	}
}