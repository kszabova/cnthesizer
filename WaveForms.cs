using System;

namespace Cnthesizer
{
	public delegate short[] WaveFormEquation(double frequency, int length, int sampleRate);

	/// <summary>
	/// Contains wave transformation methods
	/// </summary>
	internal static class WaveForms
	{
		/// <summary>
		/// Generates silence
		/// </summary>
		/// <param name="frequency">Only here to fit the definition of WaveFormEquation, can be anything</param>
		/// <param name="length">Length of the sample</param>
		/// <param name="sampleRate">Only here to fit the definition of WaveFormEquation, can be anything</param>
		/// <returns>Sound wave</returns>
		public static short[] ConstantZero(double frequency, int length, int sampleRate)
		{
			short[] wave = new short[length];
			return wave;
		}

		/// <summary>
		/// Generates a sound wave with sawtooth shape
		/// </summary>
		/// <param name="frequency">Frequency, determines pitch</param>
		/// <param name="length">Length of sample</param>
		/// <param name="sampleRate">Sample rate</param>
		/// <returns>Sound wave</returns>
		public static short[] SawtoothWave(double frequency, int length, int sampleRate)
		{
			// if frequency is zero, return constant zeros
			if (frequency == 0)
				return ConstantZero(frequency, length, sampleRate);

			short[] wave = new short[length];
			// number of samples in one 'tooth'
			int samplesPerWavelength = Convert.ToInt32(sampleRate / frequency);
			// amplitude step = total amplitude range divided by the number of steps per wavelength
			short ampStep = Convert.ToInt16((short.MaxValue * 2 - 1) / samplesPerWavelength);
			// this temporary sample has the amplitude written to it until we get to maximum amplitude
			short tempSample = short.MinValue;
			int totalSamplesWritten = 0;
			while (totalSamplesWritten < length)
			{
				tempSample = short.MinValue;
				for (int i = 0; i < samplesPerWavelength && totalSamplesWritten < length; i++)
				{
					tempSample += ampStep;
					wave[totalSamplesWritten] = tempSample;

					totalSamplesWritten++;
				}
			}
			return wave;
		}

		/// <summary>
		/// Generates a sound wave with sine shape
		/// </summary>
		/// <param name="frequency">Frequency, determines pitch</param>
		/// <param name="length">Length of sample</param>
		/// <param name="sampleRate">Sample rate</param>
		/// <returns>Sound wave</returns>
		public static short[] SineWave(double frequency, int length, int sampleRate)
		{
			short[] wave = new short[length];
			for (int i = 0; i < length; i++)
			{
				// value at point i is amplitude * sin(angular frequency * i)
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(Math.PI * 2 * frequency / sampleRate * i));
			}
			return wave;
		}

		/// <summary>
		/// Generates a sound wave with square shape
		/// </summary>
		/// <param name="frequency">Frequency, determines pitch</param>
		/// <param name="length">Length of sample</param>
		/// <param name="sampleRate">Sample rate</param>
		/// <returns>Sound wave</returns>
		public static short[] SquareWave(double frequency, int length, int sampleRate)
		{
			short[] wave = new short[length];
			for (int i = 0; i < length; i++)
			{
				// value at point i is amplitude * sgn(sin(angular frequency * i))
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin(Math.PI * 2 * frequency / sampleRate * i)));
			}
			return wave;
		}
	}
}