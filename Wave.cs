﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using NAudio.Wave;

namespace Cnthesizer
{
	public static class Wave
	{
		private static readonly int SAMPLE_RATE = 44100;
		private static readonly short BITS_PER_SAMPLE = 16;

		public static short[] SampleWaveForm(Pitch pitch, int length, Shift shift, WaveFormEquation waveForm, int sampleRate)
		{
			double baseFrequency = Frequency.GetFrequency(pitch);
			double frequency = shift(baseFrequency);
			short[] wave = waveForm(frequency, length, sampleRate);
			return wave;
		}

		public static byte[] ConvertShortWaveToBytes(short[] wave)
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

			// the beat is generated by mixing a sawtooth and a square wave
			short[] sawtooth = SampleWaveForm(Pitch.A3, length, x => x/5, WaveForms.SawtoothWave, SAMPLE_RATE);
			short[] square = SampleWaveForm(Pitch.A3, length, x => x/7, WaveForms.SquareWave, SAMPLE_RATE);
			short[] toneWave = Mixing.MixListOfWaves(new List<short[]> { sawtooth, square });

			// to get the right loudness progression, we multiply the tone wave by an exponential function
			short[] wave = new short[length];
			float frequency = 50;		// hard-coded, whatever
			for (int i = 0; i < length; ++i)
			{
				double expValue = i < length  ? Math.Pow(0.0001, (double)i / length) : 0;
				wave[i] = Convert.ToInt16(expValue * toneWave[i]);
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

		public static short[] CreateChordProgression(List<Chord> chords, int length, int bpm, Shift shift, WaveFormEquation waveForm)
		{
			int oneChordDuration = 1 / (bpm / 60) * 1000;
			List<short[]> chordWaves = new List<short[]> { };
			foreach (Chord chord in chords)
			{
				Epoch epoch = Epoch.CreateEpoch(oneChordDuration, chord.Tones);
				short[] chordWave = epoch.ConvertToWave(SAMPLE_RATE, shift, waveForm);
				chordWaves.Add(chordWave);
			}
			short[] wave = chordWaves.SelectMany(w => w).ToArray();
			short[] multipliedWave = wave.MultiplyToLength(length);
			return multipliedWave;
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
					binaryWriter.Write(sampleRate);												// 4B SampleRate
					binaryWriter.Write(sampleRate * blockAlign);								// 4B ByteRate
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

		public static void CreateWaveFile(string filename, Pitch pitch, WaveFormEquation waveForm, int sampleRate)
		{
			short[] shortWave = SampleWaveForm(pitch, sampleRate, Shifts.Unison, waveForm, sampleRate);
			byte[] binaryWave = ConvertShortWaveToBytes(shortWave);

			using (FileStream fs = File.Create(filename))
			{
				WriteToStream(fs, binaryWave, sampleRate, sampleRate, 16, 1);
			}
		}
	}
}
