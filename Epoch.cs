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
		private List<Pitch> Frequencies { get; }
		
		private Epoch(long duration, List<Pitch> frequencies)
		{
			Duration = duration;
			Frequencies = frequencies;
		}

		public static Epoch CreateEpoch(long duration, List<Pitch> frequencies)
			=> new Epoch(duration, frequencies);

		internal short[] ConvertToWave(int sampleSize, Shift shift, WaveFormEquation waveForm, int sampleRate)
		{
			int length = ConvertDurationToLength(sampleSize);
			List<short[]> waves = new List<short[]> { };
			foreach (Pitch frequency in Frequencies)
				waves.Add(Wave.SampleWaveForm(frequency, length, shift, waveForm, sampleRate));
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
