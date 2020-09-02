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

		public static MemoryStream A = CreateWave(Frequency.A);

		private static MemoryStream CreateWave(Frequency frequencyCode)
		{
			short[] wave = new short[SAMPLE_RATE];
			byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
			float frequency = Frequencies.Freqs[(int)frequencyCode];

			for (int i = 0; i < SAMPLE_RATE; ++i)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));
			}
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				short blockAlign = (short)(BITS_PER_SAMPLE / 8);
				int subchunkTwoSize = SAMPLE_RATE * blockAlign;
				binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
				binaryWriter.Write(36 + subchunkTwoSize);
				binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
				binaryWriter.Write(16);
				binaryWriter.Write((short)1);
				binaryWriter.Write((short)1);
				binaryWriter.Write(SAMPLE_RATE);
				binaryWriter.Write(SAMPLE_RATE * blockAlign);
				binaryWriter.Write(blockAlign);
				binaryWriter.Write(BITS_PER_SAMPLE);
				binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
				binaryWriter.Write(subchunkTwoSize);
				binaryWriter.Write(binaryWave);
				return memoryStream;
			}
		}
	}
}
