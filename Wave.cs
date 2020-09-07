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
			foreach (FrequenciesAvailable frequency in Enum.GetValues(typeof(FrequenciesAvailable)))
			{
				byte[] wave = CreateWave(frequency, SAMPLE_RATE);
				Waves.Add(wave);
			}
		}


		public static byte[] A = CreateWave(FrequenciesAvailable.C1, SAMPLE_RATE);

		private static byte[] CreateWave(FrequenciesAvailable frequencyCode, int length)
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

		public static byte[] CreateEmptyWave(int length = 44100)
		{
			short[] wave = new short[length];
			byte[] binaryWave = new byte[length * sizeof(short)];

			for (int i = 0; i < length; ++i)
			{
				wave[i] = 0;
			}
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}

		public static void SaveToFile(string path, byte[] wave, int length, int sampleRate, short bitsPerSample, short channels)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				short blockAlign = (short)(bitsPerSample / 8);
				int subchunkTwoSize = length * channels * blockAlign;
				binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
				binaryWriter.Write(36 + subchunkTwoSize);
				binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
				binaryWriter.Write(16);
				binaryWriter.Write((short)1);
				binaryWriter.Write(channels);
				binaryWriter.Write(SAMPLE_RATE);
				binaryWriter.Write(SAMPLE_RATE * channels * blockAlign);
				binaryWriter.Write(channels * blockAlign);
				binaryWriter.Write(BITS_PER_SAMPLE);
				binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
				binaryWriter.Write(subchunkTwoSize);
				binaryWriter.Write(wave);
				memoryStream.Seek(0, SeekOrigin.Begin);
				FileStream fs = File.Create(path);
				byte[] buf = new byte[65536];
				int len = 0;
				while ((len = memoryStream.Read(buf, 0, 65536)) > 0)
				{
					fs.Write(buf, 0, len);
				}
				fs.Close();
			}
		}
	}
}
