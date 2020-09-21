using System.Collections.Generic;

namespace Cnthesizer
{
	/// <summary>
	/// Class for handling wave mixing
	/// </summary>
	internal class Mixing
	{
		/// <summary>
		/// Takes a list of waves not necessarily of the same length
		/// and returns a sound wave corresponding to the sound
		/// when all of the waves are playing at once.
		/// </summary>
		/// <param name="waves">Input waves</param>
		/// <returns>Mixed wave</returns>
		public static short[] MixListOfWaves(List<short[]> waves)
		{
			if (waves.Count == 0) return new short[] { };

			// sort waves by their length from shortest
			waves.Sort((w1, w2) => w1.Length < w2.Length ? -1 : (w1.Length == w2.Length ? 0 : 1));

			short[] mixedWave = new short[waves[waves.Count - 1].Length];

			int n = waves.Count;
			int index = 0;
			// generate new wave as long as there are any waves left
			int waveNumber = 0;
			while (waveNumber < waves.Count)
			{
				// average samples from all waves
				for (; index < waves[waveNumber].Length; index++)
				{
					int sum = 0;
					for (int w = waveNumber; w < waves.Count; w++) sum += waves[w][index];
					mixedWave[index] = (short)(sum / n);
				}
				// when we found the end of a wave, decrement n by the number of waves of equal length
				int curLength = waves[waveNumber].Length;
				while (waveNumber < waves.Count && waves[waveNumber].Length == curLength)
				{
					waveNumber++;
					n--;
				}
			}

			return mixedWave;
		}

		/// <summary>
		/// Takes two waves not necessarily of the same length
		/// and returns wave corresponding to the sound of both 
		/// of them playing at once.
		/// Does not have the overhead of a list, therefore it
		/// is slightly better for mixing two waves than MixListOfWaves().
		/// </summary>
		/// <param name="a">First input wave</param>
		/// <param name="b">Second input wave</param>
		/// <returns>Mixed wave</returns>
		public static short[] MixTwoWaves(short[] a, short[] b)
		{
			short[] shorter = a.Length < b.Length ? a : b;
			short[] longer = a.Length < b.Length ? b : a;

			short[] mixed = new short[longer.Length];
			for (int i = 0; i < shorter.Length; i++)
			{
				mixed[i] = (short)((shorter[i] + longer[i]) / 2);
			}

			for (int i = shorter.Length; i < longer.Length; i++)
			{
				mixed[i] = longer[i];
			}

			return mixed;
		}
	}
}