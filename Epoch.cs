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

		internal short[] ConvertToWave(int sampleSize)
		{
			int length = ConvertDurationToLength(sampleSize);
			List<short[]> waves = new List<short[]> { };
			foreach (FrequenciesAvailable frequency in Frequencies)
				waves.Add(Wave.CreateShortWave(frequency, length));
			short[] mixed = Mixing.MixListOfWaves(waves);
			return mixed;
		}

		private int ConvertDurationToLength(int sampleSize)
		{
			// number of samples per milisecond * number of miliseconds
			return (int)(sampleSize / 1000 * Duration);
		}
	}
}
