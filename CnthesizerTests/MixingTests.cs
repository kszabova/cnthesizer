using Cnthesizer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CnthesizerTests
{
	public class MixingTests
	{
		[Fact] 
		public void MixListOfWaves_NoWave()
		{
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { });
			short[] expected = new short[] { };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_OneWave()
		{
			short[] wave = new short[] { 3, 1, 4, 5 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave });
			short[] expected = wave;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_TwoWavesEqualLength()
		{
			short[] wave1 = new short[] { 3, 1, 4, 5 };
			short[] wave2 = new short[] { 7, 3, 2, 9 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave1, wave2 });
			short[] expected = new short[] { 5, 2, 3, 7 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_TwoWavesSecondShorter()
		{
			short[] wave1 = new short[] { 3, 1, 4, 5 };
			short[] wave2 = new short[] { 5, 3, 2 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave1, wave2 });
			short[] expected = new short[] { 4, 2, 3, 5 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_TwoWavesFirstShorter()
		{
			short[] wave1 = new short[] { 3, 1, 4, 5 };
			short[] wave2 = new short[] { 5, 7, 4, 7, 2 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave1, wave2 });
			short[] expected = new short[] { 4, 4, 4, 6, 2 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_ThreeWavesEqualLength()
		{
			short[] wave1 = new short[] { 3, 1, 4, 5 };
			short[] wave2 = new short[] { 4, 2, 1, 4 };
			short[] wave3 = new short[] { 2, 6, 4, 3 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave1, wave2, wave3 });
			short[] expected = new short[] { 3, 3, 3, 4 };

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void MixListOfWaves_ThreeWavesAllDifferent()
		{
			short[] wave1 = new short[] { 3, 1, 4, 5 };
			short[] wave2 = new short[] { 4, 2, 1, 4, 2 };
			short[] wave3 = new short[] { 2, 6, 4 };
			short[] actual = Mixing.MixListOfWaves(new List<short[]> { wave1, wave2, wave3 });
			short[] expected = new short[] { 3, 3, 3, 4, 2 };

			Assert.Equal(expected, actual);
		}
	}
}
