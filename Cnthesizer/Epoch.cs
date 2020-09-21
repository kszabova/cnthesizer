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

		/// <summary>
		/// Creates a new Epoch instance.
		/// </summary>
		/// <param name="duration">Duration until any change/param>
		/// <param name="frequencies">Frequencies played</param>
		/// <returns></returns>
		public static Epoch CreateEpoch(long duration, List<Pitch> frequencies)
			=> new Epoch(duration, frequencies);

		/// <summary>
		/// Converts to a corresponding sound wave
		/// </summary>
		/// <param name="sampleRate">Sample rate</param>
		/// <param name="shift">Pitch shift, if any</param>
		/// <param name="waveForm">Wave form</param>
		/// <returns></returns>
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