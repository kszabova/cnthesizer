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

		public static List<byte[]> Waves = new List<byte[]> { };

		public Wave()
		{
			foreach (Frequency frequency in Enum.GetValues(typeof(Frequency)))
			{
				byte[] wave = CreateWave(frequency, SAMPLE_RATE);
				Waves.Add(wave);
			}
		}


		public static byte[] A = CreateWave(Frequency.C1, SAMPLE_RATE);

		private static byte[] CreateWave(Frequency frequencyCode, int length)
		{
			short[] wave = new short[length];
			byte[] binaryWave = new byte[length * sizeof(short)];
			float frequency = Frequencies.Freqs[(int)frequencyCode];

			for (int i = 0; i < length; ++i)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			}
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}
	}
}
