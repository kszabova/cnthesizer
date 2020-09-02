using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Cnthesizer
{
	class Wave
	{
		private static readonly int SAMPLE_RATE = 44100;
		private static readonly short BITS_PER_SAMPLE = 16;

		public static byte[] A = CreateWave(Frequency.A);

		private static byte[] CreateWave(Frequency frequencyCode)
		{
			short[] wave = new short[SAMPLE_RATE];
			byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
			float frequency = Frequencies.Freqs[(int)frequencyCode];

			for (int i = 0; i < SAMPLE_RATE; ++i)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			}
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}
	}
}
