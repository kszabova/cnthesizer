using System.Collections.Generic;

namespace Cnthesizer
{
	/// <summary>
	/// One instance of this class holds information
	/// about tones being played at the same time
	/// and their duration.
	/// </summary>
	internal class Epoch
	{
		private Epoch(long duration, List<Pitch> frequencies)
		{
			Duration = duration;
			Frequencies = frequencies;
		}

		private long Duration { get; }
		private List<Pitch> Frequencies { get; }

		public static Epoch CreateEpoch(long duration, List<Pitch> frequencies)
			=> new Epoch(duration, frequencies);

		public short[] ConvertToWave(int sampleRate, Shift shift, WaveFormEquation waveForm)
		{
			int length = ConvertDurationToLength(sampleRate);
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