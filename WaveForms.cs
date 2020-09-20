using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnthesizer
{
	public delegate short[] WaveFormEquation(double frequency, int length, int sampleRate);

	static class WaveForms
	{
		public static short[] ConstantZero(double frequency, int length, int sampleRate)
		{
			short[] wave = new short[length];
			return wave;
		}

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
	}
}
