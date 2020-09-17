using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using NAudio.Wave;

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
				byte[] wave = ConvertShortWaveToBytes(CreateShortWave(frequency, SAMPLE_RATE));
				Waves.Add(wave);
			}
		}

		public static byte[] A = ConvertShortWaveToBytes(CreateShortWave(FrequenciesAvailable.C1, SAMPLE_RATE));

		internal static short[] CreateShortWave(FrequenciesAvailable frequencyCode, int length)
		{
			short[] wave = new short[length];
			float frequency = Frequencies.Freqs[(int)frequencyCode];
			for (int i = 0; i < length; ++i)
			{
				wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * frequency) / SAMPLE_RATE) * i));  // TODO: shouldn't we replace SAMPLE RATE with length?
			}

			return wave;
		}

		internal static byte[] ConvertShortWaveToBytes(short[] wave)
		{
			byte[] binaryWave = new byte[wave.Length * sizeof(short)];
			Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
			return binaryWave;
		}

		public static short[] GenerateBeatWave(int bpm)
		{
			// 60 / bpm gives us the period of beat envelope
			// data loss from casting to int will be negligible
			int length = (int)(60f / bpm * SAMPLE_RATE);
			short[] wave = new short[length];
			byte[] binaryWave = new byte[length * sizeof(short)];
			float frequency = 440;		// hard-coded, whatever
			for (int i = 0; i < length; ++i)
			{
				double sineValue = Math.Sin(i * Math.PI / length);
				double toneWave = (short.MaxValue / 8) * Math.Sign(Math.Sin(Math.PI * 2 * frequency / SAMPLE_RATE * i));
				wave[i] = Convert.ToInt16(sineValue * toneWave);
			}
			return wave;
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

		public static void WriteToStream(Stream stream, byte[] wave, int samples, int sampleRate, short bitsPerSample, short channels)
		{
			using (MemoryStream memoryStream = new MemoryStream())
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					short blockAlign = (short)(channels * bitsPerSample / 8);
					int subchunkTwoSize = samples * blockAlign;
					binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });							// 4B ChunkID
					binaryWriter.Write(36 + subchunkTwoSize);									// 4B ChunkSize
					binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });		// 4B Format + 4B Subchunk1ID
					binaryWriter.Write(16);														// 4B Subchunk1Size
					binaryWriter.Write((short)1);												// 2B AudioFormat
					binaryWriter.Write((short)channels);										// 2B NumChannels
					binaryWriter.Write(SAMPLE_RATE);											// 4B SampleRate
					binaryWriter.Write(SAMPLE_RATE * blockAlign);								// 4B ByteRate
					binaryWriter.Write((short)(blockAlign));									// 2B BlockAlign
					binaryWriter.Write(BITS_PER_SAMPLE);										// 2B BitsPerSample
					binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });							// 4B Subchunk2Id
					binaryWriter.Write(subchunkTwoSize);										// 4B Subchunk2Size
					binaryWriter.Write(wave);													// xB Data
					memoryStream.Seek(0, SeekOrigin.Begin);
					byte[] buf = new byte[65536];
					int len = 0;
					while ((len = memoryStream.Read(buf, 0, 65536)) > 0)
					{
						stream.Write(buf, 0, len);
					}
				}
		}
	}
}
