using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	class Epoch
	{
		private long Duration { get; }
		private List<FrequenciesAvailable> Frequencies { get; }
		
		private Epoch(long duration, List<FrequenciesAvailable> frequencies)
		{
			Duration = duration;
			Frequencies = frequencies;
		}

		public static Epoch CreateEpoch(long duration, List<FrequenciesAvailable> frequencies)
			=> new Epoch(duration, frequencies);

		internal short[] ConvertToWave(int sampleSize, Shift shift)
		{
			int length = ConvertDurationToLength(sampleSize);
			List<short[]> waves = new List<short[]> { };
			foreach (FrequenciesAvailable frequency in Frequencies)
				waves.Add(Wave.CreateShortWave(frequency, length, shift));
			short[] mixed = Mixing.MixListOfWaves(waves);
			return mixed;
		}

		private int ConvertDurationToLength(int sampleSize)
		{
			// number of milliseconds * number of samples per millisecond
			return (int)(Duration * sampleSize / 1000);
		}
	}
}
